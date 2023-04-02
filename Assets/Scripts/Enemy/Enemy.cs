using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    EnemyStatsSO stats;

    [SerializeField]
    GameEventEnemyDeath _enemyDeath;

    int currentHealth;

    public UnityEvent OnEnemySpawned;

    public Vector2Int CurrentRoom { get; set; }
    public EnemyStatsSO Stats { get => stats; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = stats.Health;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _enemyDeath.Invoke(new EnemyDeathInfo{
            LastPosition = transform.position,
            Score = stats.Score
        });

        gameObject.SetActive(false);
    }
}
