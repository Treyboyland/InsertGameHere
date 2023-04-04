using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "Map/Map Piece Data")]
public class GameMapPieceUIDataSO : ScriptableObject
{
    [SerializeField]
    Color inactiveColor;

    [SerializeField]
    Color activeColor;

    [SerializeField]
    Color discoveredColor;

    [SerializeField]
    Color visitedColor;

    /// <summary>
    /// Not part of the current map; placeholder
    /// </summary>
    /// <value></value>
    public Color InactiveColor { get => inactiveColor;  }
    /// <summary>
    /// Player's current room
    /// </summary>
    /// <value></value>
    public Color ActiveColor { get => activeColor;  }
    /// <summary>
    /// Player has discovered room, but not visited the room
    /// </summary>
    /// <value></value>
    public Color DiscoveredColor { get => discoveredColor; }
    /// <summary>
    /// Player has visited this room
    /// </summary>
    /// <value></value>
    public Color VisitedColor { get => visitedColor;  }
}
