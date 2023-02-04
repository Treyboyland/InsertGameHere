using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool HasQuarter { get; set; } = false;

    public bool HasCartridge { get; set; } = false;

    public Vector2Int CurrentRoomLocation { get; set; } = new Vector2Int();
}
