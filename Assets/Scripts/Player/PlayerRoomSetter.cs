using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomSetter : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    RuntimeRoomDictionary roomDictionary;

    [SerializeField]
    GameEvent onPlayerPositionUpdated;

    [SerializeField]
    GameEventVectorInt onNewPlayerMapPosition;

    [SerializeField]
    GameEvent playerRoomUpdated;

    enum SpawnLocation { RIGHT, LEFT, TOP, BOTTOM };

    public void MovePlayerUp() => SetPlayerPosition(SpawnLocation.BOTTOM);
    public void MovePlayerDown() => SetPlayerPosition(SpawnLocation.TOP);
    public void MovePlayerLeft() => SetPlayerPosition(SpawnLocation.RIGHT);
    public void MovePlayerRight() => SetPlayerPosition(SpawnLocation.LEFT);

    private void SetPlayerPosition(SpawnLocation newSpawn)
    {
        Vector2Int playerNewLocation = player.CurrentRoomLocation;
        if (newSpawn == SpawnLocation.TOP)
        {
            playerNewLocation.y--;
        }
        else if (newSpawn == SpawnLocation.BOTTOM)
        {
            playerNewLocation.y++;
        }
        else if (newSpawn == SpawnLocation.RIGHT)
        {
            playerNewLocation.x--;
        }
        else if (newSpawn == SpawnLocation.LEFT)
        {
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
        player.SpriteController.FootstepMaterial = room.CurrentTheme.FloorType;

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

        playerRoomUpdated.Invoke();
    }
}
