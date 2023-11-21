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

    [SerializeField]
    UnityEvent _onDamage;

    int currentHealth;

    public UnityEvent OnEnemySpawned;

    [Tooltip("Fired when this specific enemy dies")]
    public UnityEvent<Vector3> OnSpecificEnemyDeath;

    public int CurrentHealth { get => currentHealth; }

    public float HealthPercentage { get => (1.0f * currentHealth) / stats.Health; }

     public int CurrentPhase
    {
        get
        {
            float healthPercentage = HealthPercentage;
            int phase = 0;

            while (stats.GetPhasePercentage(phase) < healthPercentage)
            {
                phase++;
            }

            return stats.NumPhases - phase;
        }
    }

    public bool IsDefeated { get; protected set; } = false;

    public bool IsFused { get; set; } = false;

    public bool IsInvincible { get; set; } = false;

    public Vector2Int CurrentRoom { get; set; }
    public EnemyStatsSO Stats { get => stats; }

    void Awake()
    {
        currentHealth = stats.Health;
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            IsDefeated = false;
            currentHealth = stats.Health;
        }
    }

    public void Damage(int damage)
    {
        if (!IsInvincible)
        {
            currentHealth -= damage;

            _onDamage.Invoke();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        IsDefeated = true;
        OnSpecificEnemyDeath.Invoke(transform.position);
        _enemyDeath.Invoke(new EnemyDeathInfo
        {
            LastPosition = transform.position,
            Score = stats.Score
        });

        gameObject.SetActive(false);
    }
}
