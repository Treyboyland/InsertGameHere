using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats-", menuName = "Game/Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    [Tooltip("Health that the enemy has")]
    [SerializeField]
    int health;

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


    public int Health { get => health; }
    public float Speed { get => speed; }
    public float SecondsBetweenMove { get => secondsBetweenMove; }
    public int ChallengeRating { get => challengeRating; }
    public float DistanceFromPlayer { get => distanceFromPlayer; }
    public float FireRate { get => fireRate; }
}
