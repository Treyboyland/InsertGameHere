using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignerRoomSpawnConfigs : MonoBehaviour
{
    [SerializeField]
    List<TransformLocalList> enemySpawnConfigurations;


    public List<TransformLocalList> EnemySpawnConfigurations { get => enemySpawnConfigurations; }
}
