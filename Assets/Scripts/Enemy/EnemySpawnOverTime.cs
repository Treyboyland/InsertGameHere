using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnOverTime : EnemyMove
{
    [SerializeField]
    Enemy enemyToSpawn;

    [SerializeField]
    Vector2Int numToSpawn;

    [SerializeField]
    int spawnLimit;

    [SerializeField]
    bool spawnOnDefeat;

    [SerializeField]
    RuntimeRoomDictionary roomDictionary;

    float elapsed = 0;

    int spawnCount = 0;

    private void OnEnable()
    {
        elapsed = 0;
        spawnCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldPerformAction())
        {
            CheckForSpawn();
        }
    }

    void CheckForSpawn()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= enemy.Stats.SecondsBetweenMove && spawnCount < spawnLimit)
        {
            elapsed = 0;
            spawnCount++;
            Spawn();
        }
    }

    void Spawn()
    {
        //TODO: These enemies will need to be cleared on level reset
        int numToInstantiate = numToSpawn.RandomInt();
        for (int i = 0; i < numToInstantiate; i++)
        {
            var newSpawn = Instantiate(enemyToSpawn, transform.parent);
            newSpawn.transform.position = transform.position;
            newSpawn.CurrentRoom = enemy.CurrentRoom;
            newSpawn.gameObject.SetActive(true);
            if (roomDictionary.ContainsKey(enemy.CurrentRoom))
            {
                roomDictionary[enemy.CurrentRoom].AddEnemy(newSpawn);
            }
        }
    }

    public void SpawnOnDeath(Vector3 pos)
    {
        if (spawnOnDefeat)
        {
            Spawn();
        }
    }
}
