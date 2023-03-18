using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MapData
{
    public bool[,] Map;
    public Vector2Int StartingPosition;

    public List<Vector2Int> DeadEnds;

    public int TotalChallengeRating;

    public int MaxChallengeRatingPerRoom;

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
}
