using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFuseOnCollision : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    [SerializeField]
    Enemy enemyToSpawn;

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    int maxFusions;

    [SerializeField]
    RuntimeRoomDictionary roomDictionary;


    float elapsed = 0;

    bool fused = false;

    static Dictionary<EnemyStatsSO, Dictionary<Vector2Int, int>> spawns = new Dictionary<EnemyStatsSO, Dictionary<Vector2Int, int>>();

    private void Update()
    {
        elapsed += Time.deltaTime;
    }

    private void OnEnable()
    {
        fused = false;
        elapsed = 0;
    }

    bool CanSpawn()
    {
        if (fused || elapsed < spawnDelay)
        {
            return false;
        }

        if (spawns.ContainsKey(enemyToSpawn.Stats) && spawns[enemyToSpawn.Stats].ContainsKey(enemy.CurrentRoom))
        {
            return spawns[enemyToSpawn.Stats][enemy.CurrentRoom] < maxFusions;
        }

        return !fused && elapsed >= spawnDelay;
    }

    static void AddToDictionary(Enemy enemy, int count)
    {
        if (!spawns.ContainsKey(enemy.Stats))
        {
            spawns.Add(enemy.Stats, new Dictionary<Vector2Int, int>());
        }

        if (!spawns[enemy.Stats].ContainsKey(enemy.CurrentRoom))
        {
            spawns[enemy.Stats].Add(enemy.CurrentRoom, 0);
        }

        spawns[enemy.Stats][enemy.CurrentRoom] += count;
    }

    public static void DecrementEnemy(Enemy enemy)
    {
        if (spawns.ContainsKey(enemy.Stats) && spawns[enemy.Stats].ContainsKey(enemy.CurrentRoom))
        {
            spawns[enemy.Stats][enemy.CurrentRoom]--;
        }
    }

    public static void ClearCounts()
    {
        spawns.Clear();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!CanSpawn())
        {
            return;
        }

        EnemyFuseOnCollision otherEnemy = other.gameObject.GetComponent<EnemyFuseOnCollision>();

        if (otherEnemy && enemy.Stats == otherEnemy.enemy.Stats)
        {
            fused = true;
            otherEnemy.fused = true;
            var spawnedEnemy = Instantiate(enemyToSpawn, transform.parent);
            spawnedEnemy.transform.position = other.GetContact(0).point;
            spawnedEnemy.CurrentRoom = enemy.CurrentRoom;
            spawnedEnemy.gameObject.SetActive(true);
            AddToDictionary(spawnedEnemy, 1);
            if (roomDictionary.ContainsKey(enemy.CurrentRoom))
            {
                roomDictionary[enemy.CurrentRoom].AddEnemy(spawnedEnemy);
            }
            gameObject.SetActive(false);
            otherEnemy.gameObject.SetActive(false);
        }
    }
}
