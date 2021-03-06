using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Room : MonoBehaviour
{
    [SerializeField]
    bool isOpen;

    public UnityEvent<bool> OnOpenStateChanged = new UnityEvent<bool>();

    public bool IsOpen
    { get { return isOpen; } set { isOpen = value; OnOpenStateChanged.Invoke(isOpen); } }

    /// <summary>
    /// Location of this room on the map
    /// </summary>
    Vector2Int roomLocation;

    /// <summary>
    /// Location of this room on the map
    /// </summary>
    /// <value></value>
    public Vector2Int RoomLocation { get { return roomLocation; } set { roomLocation = value; } }

    [SerializeField]
    GameObject leftPlayerSpawn, rightPlayerSpawn, upPlayerSpawn, downPlayerSpawn, centerPlayerSpawn;

    [SerializeField]
    DoorType leftDoor, rightDoor, upDoor, downDoor;

    public GameObject LeftPlayerSpawn { get { return leftPlayerSpawn; } }
    public GameObject RightPlayerSpawn { get { return rightPlayerSpawn; } }
    public GameObject UpPlayerSpawn { get { return upPlayerSpawn; } }
    public GameObject DownPlayerSpawn { get { return downPlayerSpawn; } }
    public GameObject CenterPlayerSpawn { get { return centerPlayerSpawn; } }

    public bool CanLeftOpen { get; set; } = false;
    public bool CanRightOpen { get; set; } = false;
    public bool CanUpOpen { get; set; } = false;
    public bool CanDownOpen { get; set; } = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    public bool CanDoorOpen(DoorType doorType)
    {
        if (doorType == leftDoor)
        {
            return CanLeftOpen;
        }
        else if (doorType == rightDoor)
        {
            return CanRightOpen;
        }
        else if (doorType == upDoor)
        {
            return CanUpOpen;
        }
        else if (doorType == downDoor)
        {
            return CanDownOpen;
        }
        return false;
    }
}
