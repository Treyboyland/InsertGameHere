using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Linq;

public struct MapData
{
    public bool IsFailure;
    public bool[,] Map;
    public Vector2Int StartingPosition;

    public List<Vector2Int> DeadEnds;

    public int TotalChallengeRating;

    public int MaxChallengeRatingPerRoom;

    public int NumRoomsInMap;

    public int TargetRoomCount;

    public int Level;

    public bool IsWithinBounds(Vector2Int pos)
    {
        return pos.x < Map.GetLength(0) && pos.x >= 0 && pos.y < Map.GetLength(1) && pos.y >= 0;
    }

    public bool HasNeighborUp(Vector2Int pos)
    {
        pos.y++;
        return IsWithinBounds(pos) && Map[pos.x, pos.y];
    }

    public bool HasNeighborDown(Vector2Int pos)
    {
        pos.y--;
        return IsWithinBounds(pos) && Map[pos.x, pos.y];
    }

    public bool HasNeighborLeft(Vector2Int pos)
    {
        pos.x--;
        return IsWithinBounds(pos) && Map[pos.x, pos.y];
    }

    public bool HasNeighborRight(Vector2Int pos)
    {
        pos.x++;
        return IsWithinBounds(pos) && Map[pos.x, pos.y];
    }

    public string TargetData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Map: Failure:{IsFailure}, Rooms: {NumRoomsInMap}, Target Count: {TargetRoomCount}");
        return sb.ToString();
    }

    string GetRoomLayout()
    {
        StringBuilder sb = new StringBuilder();
        for (int x = 0; x < Map.GetLength(0); x++)
        {
            for (int y = 0; y < Map.GetLength(1); y++)
            {
                string character = "X";
                if (Map[x, y])
                {
                    var pos = new Vector2Int(x, y);
                    character = pos == StartingPosition ? "V" : (DeadEnds.Contains(pos) ? "E" : "O");
                }

                sb.Append(character);
            }
            sb.Append("\n");
        }
        return sb.ToString();
    }

    int GetRoomCount()
    {
        int count = 0;
        foreach (var room in Map)
        {
            if (room)
            {
                count++;
            }
        }

        return count;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Failed {IsFailure}, Level {Level}, Rooms {NumRoomsInMap}, Target {TargetRoomCount}, DeadEnds: {DeadEnds.Count}, Calculated Rooms: {GetRoomCount()}");
        sb.Append(GetRoomLayout());
        return sb.ToString();
    }
}
