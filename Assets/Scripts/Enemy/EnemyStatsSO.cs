using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats-", menuName = "Game/Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    [Tooltip("Health that the enemy has")]
    [SerializeField]
    int health;

    [Tooltip("Number of phases that this enemy has")]
    [SerializeField]
    int numPhases;

    [Tooltip("How fast the enemy moves")]
    [SerializeField]
    float speed;

    [Tooltip("If a distance threshold from the player is needed, this should be used as the cutoff")]
    [SerializeField]
    float distanceFromPlayer;

    [Tooltip("Seconds between moves")]
    [SerializeField]
    float secondsBetweenMove;

    [Tooltip("If enemy has a projectile, this will be when it is fired normally")]
    [SerializeField]
    float fireRate;

    [Tooltip("How difficult this enemy is")]
    [SerializeField]
    int challengeRating;

    [Tooltip("How much this enemy is worth when defeated")]
    [SerializeField]
    int score;

    [Tooltip("Room that this enemy can spawn in")]
    [SerializeField]
    RoomThemeSO roomTheme;

    public int Health { get => health; }
    public float Speed { get => speed; }
    public float SecondsBetweenMove { get => secondsBetweenMove; }
    public int ChallengeRating { get => challengeRating; }
    public float DistanceFromPlayer { get => distanceFromPlayer; }
    public float FireRate { get => fireRate; }
    public int Score { get => score; }
    public RoomThemeSO RoomTheme { get => roomTheme; }
    public int NumPhases { get => numPhases; }

    public float GetPhasePercentage(int phase)
    {
        if (phase >= numPhases)
        {
            return 1;
        }

        return (1.0f * phase) / numPhases;
    }
}
