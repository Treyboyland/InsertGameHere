using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    EnemyStatsSO stats;

    int currentHealth;

    public UnityEvent OnEnemySpawned;

    public Vector2Int CurrentRoom { get; set; }
    public EnemyStatsSO Stats { get => stats; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = stats.Health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
