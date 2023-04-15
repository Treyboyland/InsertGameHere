using System.Collections;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomTheme", menuName = "Room/Room Theme")]
public class RoomThemeSO : ScriptableObject
{
    [SerializeField]
    Sprite background;

    [SerializeField]
    Sprite wall;

    [SerializeField]
    Sprite obstacle;

    [SerializeField]
    AK.Wwise.Switch floorType;

    public Sprite Background { get => background; }
    public Sprite Wall { get => wall; }
    public Sprite Obstacle { get => obstacle; }
    public Switch FloorType { get => floorType;}
}
