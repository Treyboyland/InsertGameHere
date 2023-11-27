using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    EnemyDatabaseSO database;

    [SerializeField]
    rho.ConfigFloat secondsBeforeSpawn;

    [SerializeField]
    ParticleStopOnEnemySpawn spawnParticle;

    [SerializeField]
    RoomThemeSO anyTheme;

    bool enemySpawned = false;

    Enemy prefabSelected = null;

    Enemy spawnedEnemyObject = null;

    public RoomThemeSO CurrentTheme { get; set; }

    /// <summary>
    /// Will attempt to spawn an enemy with the given challenge rating
    /// </summary>
    /// <param name="challengeRating"></param>
    public void SelectEnemy(int challengeRating)
    {
        //Roll for monsters in theme
        var potentialEnemies = database.Enemies.Where(x => x.Stats.ChallengeRating == challengeRating &&
            x.Stats.RoomTheme == CurrentTheme).ToList();

        if (potentialEnemies.Count == 0)
        {
            potentialEnemies = database.Enemies.Where(x => x.Stats.ChallengeRating <= challengeRating &&
                x.Stats.RoomTheme == CurrentTheme).ToList();
        }

        if (potentialEnemies.Count != 0)
        {
            int index = Random.Range(0, potentialEnemies.Count);
            prefabSelected = potentialEnemies[index];
            return;
        }

        //Roll from miscelaneous monsters
        var additionalEnemies = database.Enemies.Where(x => x.Stats.ChallengeRating == challengeRating &&
            x.Stats.RoomTheme == anyTheme).ToList();

        if (additionalEnemies.Count == 0)
        {
            additionalEnemies = database.Enemies.Where(x => x.Stats.ChallengeRating <= challengeRating &&
                x.Stats.RoomTheme == anyTheme).ToList();
        }

        potentialEnemies.AddRange(additionalEnemies);

        if (potentialEnemies.Count != 0)
        {
            int index = Random.Range(0, potentialEnemies.Count);
            prefabSelected = potentialEnemies[index];
        }
        else if (database.Enemies != null && database.Enemies.Count != 0)
        {
            //Roll from all enemies in game
            int index = Random.Range(0, database.Enemies.Count);
            prefabSelected = database.Enemies[index];
        }
        else
        {
            prefabSelected = null;
        }
    }

    public void SpawnEnemy(Room room)
    {
        //Debug.LogWarning("Spawned Enemy at (" + room.RoomLocation + "):" + (spawnedEnemyObject != null));
        if (prefabSelected != null && !spawnedEnemyObject)
        {
            StartCoroutine(BeginSpawning(room));
        }
    }

    public void DestroySpawnedEnemy()
    {
        if (spawnedEnemyObject)
        {
            Destroy(spawnedEnemyObject.gameObject);
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

        yield return new WaitForSeconds(secondsBeforeSpawn.Value);

        spawnedEnemyObject.gameObject.SetActive(true);
        enemySpawned = true;
    }

}
