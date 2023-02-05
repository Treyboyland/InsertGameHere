using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    EnemyStatsSO stats;

    int currentHealth;

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
            gameObject.SetActive(false);
        }
    }
}
