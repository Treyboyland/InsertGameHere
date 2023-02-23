using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyItemDrop : MonoBehaviour
{
    [SerializeField]
    DropTableSO table;

    [SerializeField]
    float dropProbability;

    public void SpawnItem(Vector3 pos)
    {
        float probality = Random.Range(0.0f, 1.0f);

        if (probality > dropProbability)
        {
            return;
        }

        var itemToSpawn = table.GetGameObject();
        var spawnedObject = Instantiate(itemToSpawn);
        spawnedObject.transform.position = pos;
        //TODO: Pool this? Probably also handle reset
        spawnedObject.SetActive(true);
    }
}
