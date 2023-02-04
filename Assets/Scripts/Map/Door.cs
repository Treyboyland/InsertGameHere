using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer doorSprite;

    [SerializeField]
    Collider2D doorCollider;

    [SerializeField]
    RoomTrigger triggerForDoor;

    [SerializeField]
    Room room;

    [SerializeField]
    DoorType doorType;

    // Start is called before the first frame update
    void Awake()
    {
        room.OnOpenStateChanged.AddListener(state =>
        {
            SetDoorState(state);
        });
        SetDoorState(room.IsOpen);
    }

    void SetDoorState(bool open)
    {
        open = open && room.CanDoorOpen(doorType);
        doorCollider.enabled = !open;
        var color = doorSprite.color;
        color.a = open ? 0 : 1;
        doorSprite.color = color;
        triggerForDoor.Trigger.enabled = open;
    }
}
