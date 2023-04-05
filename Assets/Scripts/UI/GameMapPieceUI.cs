using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMapPieceUI : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    GameMapPieceUIDataSO colorData;

    bool isVisited = false;

    /// <summary>
    /// True if this is actually part of the current map, and not
    /// a placeholder
    /// </summary>
    /// <value></value>
    public bool IsActiveRoom { get; set; } = false;

    public bool IsDiscovered { get; set; } = false;

    public Vector2Int CurrentPosition { get; set; }

    public bool IsSpecial { get; set; }

    public void ResetData()
    {
        IsActiveRoom = false;
        IsDiscovered = false;
        isVisited = false;
        CurrentPosition = Vector2Int.zero;
        IsSpecial = false;
    }

    public void SetColors(Vector2Int currentPos)
    {
        if (!IsActiveRoom)
        {
            image.color = colorData.InactiveColor;
        }
        else if (currentPos == CurrentPosition)
        {
            image.color = colorData.ActiveColor;
            isVisited = true;
        }
        else if (IsDiscovered)
        {
            if (IsSpecial)
            {
                image.color = colorData.SpecialRoomColor;
            }
            else
            {
                image.color = isVisited ? colorData.VisitedColor : colorData.DiscoveredColor;
            }
        }
        else
        {
            image.color = colorData.InactiveColor;
        }
    }
}
