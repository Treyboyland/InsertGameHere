using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignerRoom : MonoBehaviour
{
    [Tooltip("Objects underneath this will be spawned")]
    [SerializeField]
    Transform spawnParent;

    [SerializeField]
    DesignerRoomSpawnConfigs spawnConfig;

    public static implicit operator List<RoomDataSO.SpawnData>(DesignerRoom room)
    {
        List<RoomDataSO.SpawnData> spawns = new List<RoomDataSO.SpawnData>();

        for (int i = 0; i < room.spawnParent.childCount; i++)
        {
            GameObject obj = room.spawnParent.GetChild(i).gameObject;
            Vector2 location = obj.transform.localPosition;
            spawns.Add(new RoomDataSO.SpawnData() { Prefab = obj, Location = location });
        }

        return spawns;
    }

    public static implicit operator EverythingARoomNeedsForSpawn(DesignerRoom room)
    {
        List<RoomDataSO.SpawnData> spawns = new List<RoomDataSO.SpawnData>();

        for (int i = 0; i < room.spawnParent.childCount; i++)
        {
            GameObject obj = room.spawnParent.GetChild(i).gameObject;
            Vector2 location = obj.transform.localPosition;
            spawns.Add(new RoomDataSO.SpawnData() { Prefab = obj, Location = location });
        }

        List<List<Vector2>> enemySpawns = new List<List<Vector2>>();

        foreach (var config in room.spawnConfig.EnemySpawnConfigurations)
        {
            enemySpawns.Add(config);
        }

        return new EverythingARoomNeedsForSpawn() { Spawns = spawns, EnemySpawnLocations = enemySpawns };
    }
}
