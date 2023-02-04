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

    [Serializable]
    public struct SpawnData
    {
        public GameObject Prefab;
        public Vector2 Location;
    }
}
