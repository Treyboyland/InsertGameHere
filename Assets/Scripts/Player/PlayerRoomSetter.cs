using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomSetter : MonoBehaviour
{
    [SerializeField]
    RuntimeGameObject playerRef;

    [SerializeField]
    RuntimeRoomDictionary roomDictionary;

    [SerializeField]
    GameEvent onPlayerPositionUpdated;

    [SerializeField]
    GameEventVectorInt onNewPlayerMapPosition;

    [SerializeField]
    GameEvent moveDownEvent, moveUpEvent, moveLeftEvent, moveRightEvent;

    enum SpawnLocation { RIGHT, LEFT, TOP, BOTTOM };

    public void SetPlayerPosition(GameEvent moveEvent)
    {
        //Debug.LogWarning("Should move player");
        var player = playerRef.Value.GetComponent<Player>();
        Vector2Int playerNewLocation = player.CurrentRoomLocation;
        SpawnLocation newSpawn = SpawnLocation.LEFT;
        if (moveEvent == moveDownEvent)
        {
            newSpawn = SpawnLocation.TOP;
            playerNewLocation.y--;
        }
        else if (moveEvent == moveUpEvent)
        {
            newSpawn = SpawnLocation.BOTTOM;
            playerNewLocation.y++;
        }
        else if (moveEvent == moveLeftEvent)
        {
            newSpawn = SpawnLocation.RIGHT;
            playerNewLocation.x--;
        }
        else if (moveEvent == moveRightEvent)
        {
            newSpawn = SpawnLocation.LEFT;
            playerNewLocation.x++;
        }

        var room = roomDictionary.GetRoomAtLocation(playerNewLocation);

        if (room == null)
        {
            Debug.LogError("Missing room for location: " + playerNewLocation);
            return;
        }

        //Flip on entrance to other room

        player.CurrentRoomLocation = playerNewLocation;

        switch (newSpawn)
        {
            case SpawnLocation.LEFT:
                player.transform.position = room.LeftPlayerSpawn.transform.position;
                break;
            case SpawnLocation.RIGHT:
                player.transform.position = room.RightPlayerSpawn.transform.position;
                break;
            case SpawnLocation.TOP:
                player.transform.position = room.UpPlayerSpawn.transform.position;
                break;
            case SpawnLocation.BOTTOM:
                player.transform.position = room.DownPlayerSpawn.transform.position;
                break;
        }

        onPlayerPositionUpdated.Invoke();
        Vector3Int pos = new Vector3Int(player.CurrentRoomLocation.x, player.CurrentRoomLocation.y, 0);
        onNewPlayerMapPosition.Value = pos;
        onNewPlayerMapPosition.Invoke();
    }
}
