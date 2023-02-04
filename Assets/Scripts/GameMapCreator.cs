using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapCreator : MonoBehaviour
{
    [SerializeField]
    ObjectPool roomPool;

    [SerializeField]
    MapGenerator generator;

    [SerializeField]
    Vector2 dimensions;

    [SerializeField]
    Vector2 spacing;

    [SerializeField]
    Player player;

    [SerializeField]
    GameEvent onSetPlayerStartingPosition;

    [SerializeField]
    RoomDataSO coinRoom;

    [SerializeField]
    RoomDataSO cabinetRoom;

    [SerializeField]
    RoomDataSO cartridgeRoom;

    MapGenerator.MapData mapData;

    Dictionary<Vector2Int, Room> roomDictionary = new Dictionary<Vector2Int, Room>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateGameMap();
    }

    public void GenerateGameMap()
    {
        roomPool.DisableAll();
        mapData = generator.GenerateMap();
        roomDictionary.Clear();
        for (int x = 0; x < mapData.Map.GetLength(0); x++)
        {
            for (int y = 0; y < mapData.Map.GetLength(1); y++)
            {
                if (mapData.Map[x, y])
                {
                    Vector2 position = new Vector2(x * dimensions.x + x * spacing.x, y * dimensions.y + y * spacing.y);
                    var room = roomPool.GetObject();
                    room.transform.position = position;
                    var roomData = room.GetComponent<Room>();
                    if (roomData != null)
                    {
                        roomData.RoomLocation = new Vector2Int(x, y);
                        roomData.CanUpOpen = mapData.HasNeighborUp(roomData.RoomLocation);
                        roomData.CanDownOpen = mapData.HasNeighborDown(roomData.RoomLocation);
                        roomData.CanLeftOpen = mapData.HasNeighborLeft(roomData.RoomLocation);
                        roomData.CanRightOpen = mapData.HasNeighborRight(roomData.RoomLocation);
                        roomData.IsOpen = false;
                        roomData.IsOpen = true;
                        if (roomData.RoomLocation == mapData.StartingPosition)
                        {
                            player.transform.position = roomData.CenterPlayerSpawn.transform.position;
                            player.CurrentRoomLocation = roomData.RoomLocation;
                        }
                        roomDictionary.Add(roomData.RoomLocation, roomData);
                    }
                    room.SetActive(true);

                }
            }
        }

        mapData.DeadEnds.Shuffle();
        Vector2Int coinRoomLocation, cartridgeRoomLocation, cabinetRoomLocation;

        coinRoomLocation = mapData.DeadEnds[0];
        cartridgeRoomLocation = mapData.DeadEnds[1];
        cabinetRoomLocation = mapData.DeadEnds[2];

        roomDictionary[coinRoomLocation].GenerateRoomStuff(coinRoom);
        roomDictionary[cartridgeRoomLocation].GenerateRoomStuff(cartridgeRoom);
        roomDictionary[cabinetRoomLocation].GenerateRoomStuff(cabinetRoom);

        onSetPlayerStartingPosition.Invoke();

        // player.transform.position = new Vector3(mapData.StartingPosition.x * dimensions.x + spacing.x * mapData.StartingPosition.x,
        //     mapData.StartingPosition.y * dimensions.y + spacing.y + mapData.StartingPosition.y);
    }

    public Room GetRoomAtLocation(Vector2Int location)
    {
        if (!roomDictionary.ContainsKey(location))
        {
            return null;
        }
        return roomDictionary[location];
    }
}
