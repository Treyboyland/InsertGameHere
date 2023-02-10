using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "RoomData", menuName = "Game/Room Data")]
public class RoomDataSO : ScriptableObject
{
    [Tooltip("Prefabs to Spawn, and their positions")]
    [SerializeField]
    List<SpawnData> spawns;

    public List<SpawnData> Spawns { get => spawns; }

    [Tooltip("Places where enemies can spawn")]
    [SerializeField]
    List<Vector2List> enemySpawnPositions;

    [Serializable]
    public struct SpawnData
    {
        public GameObject Prefab;
        public Vector2 Location;
    }

    public static implicit operator List<SpawnData>(RoomDataSO data)
    {
        return data.spawns;
    }

    public static implicit operator EverythingARoomNeedsForSpawn(RoomDataSO data)
    {
        List<List<Vector2>> enemies = new List<List<Vector2>>();
        foreach (var spawnPos in data.enemySpawnPositions)
        {
            enemies.Add(spawnPos);
        }

        return new EverythingARoomNeedsForSpawn() { Spawns = data.spawns, EnemySpawnLocations = enemies };
    }
}
