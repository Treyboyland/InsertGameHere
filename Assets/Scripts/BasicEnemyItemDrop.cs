using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyItemDrop : MonoBehaviour
{
    [SerializeField]
    DropTableAbstract table;

    [SerializeField]
    float dropProbability;

    public void SpawnItem(EnemyDeathInfo info)
    {
        SpawnItem(info.LastPosition);
    }

    public void SpawnItem(Vector3 pos)
    {
        float probality = Random.Range(0.0f, 1.0f);

        if (probality > dropProbability)
        {
            return;
        }

        var itemToSpawn = table.GetGameObject();
        if (ItemSpawner.Instance)
        {
            var spawnedObject = ItemSpawner.Instance.SpawnItem(itemToSpawn);
            spawnedObject.transform.position = pos;
            spawnedObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Need an item spawner prefab in scene");
        }
    }
}
