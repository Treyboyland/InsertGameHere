using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    EnemyDatabaseSO database;

    [SerializeField]
    FloatValueSO secondsBeforeSpawn;

    [SerializeField]
    ParticleStopOnEnemySpawn spawnParticle;

    bool enemySpawned = false;

    Enemy prefabSelected = null;

    Enemy spawnedEnemyObject = null;

    /// <summary>
    /// Will attempt to spawn an enemy with the given challenge rating
    /// </summary>
    /// <param name="challengeRating"></param>
    public void SelectEnemy(int challengeRating)
    {
        var potentialEnemies = database.Enemies.Where(x => x.Stats.ChallengeRating == challengeRating).ToList();

        if (potentialEnemies.Count == 0)
        {
            potentialEnemies = database.Enemies.Where(x => x.Stats.ChallengeRating <= challengeRating).ToList();
        }

        if (potentialEnemies.Count == 0)
        {
            return;
        }

        int index = Random.Range(0, potentialEnemies.Count);

        prefabSelected = potentialEnemies[index];
    }

    public void SpawnEnemy(Room room)
    {
        if (prefabSelected != null && !spawnedEnemyObject)
        {
            StartCoroutine(BeginSpawning(room));
        }
    }

    public void StopEnemySpawn()
    {
        StopAllCoroutines();
        if (!enemySpawned && spawnedEnemyObject)
        {
            Destroy(spawnedEnemyObject.gameObject);
        }
        
        spawnParticle.gameObject.SetActive(false);
        spawnParticle.Enemy = null;
    }

    IEnumerator BeginSpawning(Room room)
    {
        spawnedEnemyObject = Instantiate(prefabSelected, room.transform);
        spawnParticle.Enemy = spawnedEnemyObject;
        spawnedEnemyObject.gameObject.SetActive(false);
        spawnParticle.gameObject.SetActive(true);
        spawnedEnemyObject.transform.position = transform.position;
        spawnedEnemyObject.CurrentRoom = room.RoomLocation;

        yield return new WaitForSeconds(secondsBeforeSpawn);

        spawnedEnemyObject.gameObject.SetActive(true);
        enemySpawned = true;
    }

}
