using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    Vector2Int dimensions;

    public Vector2Int Dimensions { get { return dimensions; } set { dimensions = value; } }

    [SerializeField]
    int level;

    public int Level { get { return level; } set { level = value; } }

    const int MIN_ROOMS = 4;

    /// <summary>
    /// Coin, Cartridge, Cabinet
    /// </summary>
    public const int NUM_SPECIAL_ROOMS = 3;

    public MapData GenerateMap()
    {
        if (dimensions.x * dimensions.y < MIN_ROOMS)
        {
            Debug.LogError("You need higher dimensions");
            return new MapData { Map = new bool[0, 0], StartingPosition = new Vector2Int(), DeadEnds = new List<Vector2Int>() };
        }
        bool[,] mapGrid = new bool[dimensions.x, dimensions.y];
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        var start = new Vector2Int(mapGrid.GetLength(0) / 2, mapGrid.GetLength(1) / 2);
        mapGrid[start.x, start.y] = true;
        queue.Enqueue(start);

        int numRooms = Random.Range(7, 9) + (int)(level * 2.6);
        int roomsAdded = 1;
        List<Vector2Int> deadends = new List<Vector2Int>();

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
                if (!IsWithinBounds(mapGrid, neighbor))
                {
                    continue;
                }
                if (mapGrid[neighbor.x, neighbor.y] || GetNumFilledNeighbors(mapGrid, neighbor) > 1 || Random.Range(0.0f, 1.0f) >= 0.6f)
                {
                    continue;
                }
                else
                {
                    mapGrid[neighbor.x, neighbor.y] = true;
                    roomsAdded++;
                    queue.Enqueue(neighbor);
                    neighborsMade++;
                }
            }
            if (neighborsMade == 0 && !deadends.Contains(pos))
            {
                deadends.Add(pos);
            }
        }

        if (roomsAdded < numRooms || deadends.Count < NUM_SPECIAL_ROOMS)
        {
            return GenerateMap();
        }

        Debug.LogWarning(GetRoomLayout(mapGrid));
        Debug.LogWarning("Starting Position: " + start);


        return new MapData
        {
            Map = mapGrid,
            StartingPosition = start,
            DeadEnds = deadends,
            MaxChallengeRatingPerRoom = 5,
            TotalChallengeRating = 5 * (roomsAdded - deadends.Count)
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

    bool IsWithinBounds(bool[,] grid, Vector2Int location)
    {
        return location.x < grid.GetLength(0) && location.x >= 0 && location.y < grid.GetLength(1) && location.y >= 0;
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

    int GetNumFilledNeighbors(bool[,] grid, Vector2Int location)
    {
        var xMax = grid.GetLength(0);
        var yMax = grid.GetLength(1);

        List<Vector2Int> neighborAdds = GetNeighborCells(location);

        int count = 0;

        foreach (var pos in neighborAdds)
        {
            if (pos == location)
            {
                continue;
            }
            if (IsWithinBounds(grid, pos) && grid[pos.x, pos.y])
            {
                count++;
            }
        }

        return count;
    }

    public void IncreaseLevel()
    {
        level++;
    }
}
