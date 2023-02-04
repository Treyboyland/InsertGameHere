using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorType", menuName = "Room/Door Type")]
public class DoorType : ScriptableObject
{
    [SerializeField]
    string doorName;

    public string DoorName { get { return doorName; } }
}
