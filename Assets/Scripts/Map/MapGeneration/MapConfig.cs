using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig", menuName = "Map/Map Config")]
public class MapConfig : ScriptableObject
{
    #region Fields
    [SerializeField] Vector2Int _dimensions;
    [SerializeField] public int _numSpecialRooms = 3;
    [SerializeField] int maxAttempts;
    [SerializeField] int maxNumRooms;
    #endregion

    #region Methods
    public MapData GenerateMap(int level)
    {
        MapData lastMap = new MapData();
        for (int i = 0; i < maxAttempts; i++)
        {
            var map = GenerateMapStep(level);
            if (!map.IsFailure)
            {
                Debug.LogWarning(map);
                return map;
            }
            lastMap = map;
        }

        Debug.LogWarning($"Surpassed generation attempts. Creating failure map for level {level}");
        Debug.LogWarning($"Last Map Generated: {lastMap.TargetData()}");

        bool[,] failureMap = new bool[_numSpecialRooms * 2, 2];
        Vector2Int startingPosition = new Vector2Int(_numSpecialRooms, 0);
        List<Vector2Int> deadEnds = new List<Vector2Int>();
        int count = 0;


        for (int x = 0; x < failureMap.GetLength(0); x++)
        {
            for (int y = 0; y < failureMap.GetLength(1); y++)
            {
                bool added = y == 0 || x % 2 == 0;
                failureMap[x, y] = added;
                count++;
            }
        }

        return new MapData
        {
            Level = level,
            IsFailure = false,
            Map = failureMap,
            StartingPosition = startingPosition,
            DeadEnds = deadEnds,
            MaxChallengeRatingPerRoom = 5,
            TotalChallengeRating = 5 * (count - deadEnds.Count)
        };
    }

    bool TestAddPositionToGrid(Dictionary<Vector2Int, bool> mapGrid, Vector2Int neighbor, bool forceExpansion)
    {
        if ((mapGrid.ContainsKey(neighbor) && mapGrid[neighbor]) || GetNumFilledNeighbors(mapGrid, neighbor) > 1 || (!forceExpansion && Random.Range(0.0f, 1.0f) >= 0.6f))
        {
            return false;
        }
        else
        {
            SetMapPlaceActive(mapGrid, neighbor);
            return true;
        }
    }

    void MapGenLoop(Dictionary<Vector2Int, bool> mapGrid, Queue<Vector2Int> queue, List<Vector2Int> deadends, ref int roomsAdded, ref int numRooms, bool addToQueue, bool forceExpansion)
    {
        while (queue.Count != 0 && roomsAdded < numRooms)
        {
            var pos = queue.Dequeue();
            int neighborsMade = 0;
            foreach (var neighbor in GetNeighborCells(pos))
            {
                if (roomsAdded >= numRooms)
                {
                    break;
                }
                if (TestAddPositionToGrid(mapGrid, neighbor, forceExpansion))
                {
                    roomsAdded++;
                    queue.Enqueue(neighbor);
                    neighborsMade++;
                }
            }
            if (neighborsMade == 0 && !deadends.Contains(pos) && addToQueue)
            {
                deadends.Add(pos);
            }
        }
    }

    void SetMapPlaceActive(Dictionary<Vector2Int, bool> map, Vector2Int location)
    {
        if (!map.ContainsKey(location))
        {
            map.Add(location, true);
        }
        map[location] = true;
    }

    bool[,] ConvertToGameMap(Dictionary<Vector2Int, bool> map, out Vector2Int offset)
    {
        int xMin = map.Keys.Select(pos => pos.x).Min();
        int yMin = map.Keys.Select(pos => pos.y).Min();

        int xMax = map.Keys.Select(pos => pos.x).Max();
        int yMax = map.Keys.Select(pos => pos.y).Max();

        Vector2Int maxPos = new Vector2Int(xMax, yMax);
        offset = new Vector2Int(Mathf.Abs(xMin), Mathf.Abs(yMin));

        bool[,] mapGrid = new bool[maxPos.x + offset.x + 1, maxPos.y + offset.y + 1];

        foreach (var pos in map.Keys)
        {
            var mapPos = pos + offset;
            mapGrid[mapPos.x, mapPos.y] = true;
        }

        return mapGrid;
    }

    MapData GenerateMapStep(int level)
    {
        // if (_dimensions.x * _dimensions.y < _numSpecialRooms)
        // {
        //     Debug.LogError("You need higher dimensions");
        //     return new MapData { IsFailure = true, Map = new bool[0, 0], StartingPosition = new Vector2Int(), DeadEnds = new List<Vector2Int>() };
        // }
        Dictionary<Vector2Int, bool> genMap = new Dictionary<Vector2Int, bool>();
        //bool[,] mapGrid = new bool[_dimensions.x, _dimensions.y];
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        var start = Vector2Int.zero;
        //var start = new Vector2Int(mapGrid.GetLength(0) / 2, mapGrid.GetLength(1) / 2);
        //mapGrid[start.x, start.y] = true;
        SetMapPlaceActive(genMap, start);
        queue.Enqueue(start);

        int numRooms = Random.Range(7, 9) + (int)(level * 2.6);

        if(maxNumRooms > 0 && maxNumRooms >= _numSpecialRooms + 1 && numRooms > maxNumRooms)
        {
            numRooms = maxNumRooms;
        }

        int roomsAdded = 1;
        List<Vector2Int> deadends = new List<Vector2Int>();

        MapGenLoop(genMap, queue, deadends, ref roomsAdded, ref numRooms, true, false);

        if (roomsAdded < numRooms && deadends.Count > _numSpecialRooms)
        {
            deadends.Shuffle();
            while (deadends.Count > _numSpecialRooms)
            {
                queue.Enqueue(deadends[0]);
                deadends.RemoveAt(0);
                MapGenLoop(genMap, queue, deadends, ref roomsAdded, ref numRooms, false, true);
            }
        }


        bool[,] mapGrid = ConvertToGameMap(genMap, out Vector2Int offset);
        start += offset;

        for (int i = 0; i < deadends.Count; i++)
        {
            deadends[i] = deadends[i] + offset;
        }

        //Debug.Log(GetRoomLayout(mapGrid));
        //Debug.Log("Starting Position: " + start);

        return new MapData
        {
            Level = level,
            IsFailure = roomsAdded < numRooms || deadends.Count < _numSpecialRooms,
            Map = mapGrid,
            StartingPosition = start,
            DeadEnds = deadends,
            MaxChallengeRatingPerRoom = 5,
            TotalChallengeRating = 5 * (roomsAdded - deadends.Count),
            NumRoomsInMap = roomsAdded,
            TargetRoomCount = numRooms
        };
    }

    string GetRoomLayout(bool[,] grid)
    {
        StringBuilder sb = new StringBuilder();
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                sb.Append(grid[x, y] ? "T" : "F");
            }
            sb.Append("\n");
        }
        return sb.ToString();
    }

    List<Vector2Int> GetNeighborCells(Vector2Int position)
    {
        List<Vector2Int> neighborAdds = new List<Vector2Int>(){
            new Vector2Int(-1,0),
            new Vector2Int(1,0),
            new Vector2Int(0,1),
            new Vector2Int(0,-1)
        };

        for (int i = 0; i < neighborAdds.Count; i++)
        {
            neighborAdds[i] += position;
        }

        return neighborAdds;
    }

    int GetNumFilledNeighbors(Dictionary<Vector2Int, bool> grid, Vector2Int location)
    {
        List<Vector2Int> neighborAdds = GetNeighborCells(location);

        int count = 0;

        foreach (var pos in neighborAdds)
        {
            if (pos == location)
            {
                continue;
            }
            if (grid.ContainsKey(pos) && grid[pos])
            {
                count++;
            }
        }

        return count;
    }
    #endregion
}
