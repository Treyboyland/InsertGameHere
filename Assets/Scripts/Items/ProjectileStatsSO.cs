using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileStats", menuName = "Game/Projectile Stats")]
public class ProjectileStatsSO : ScriptableObject
{
    [Tooltip("Damage this projectile does")]
    [SerializeField]
    int damage;

    [Tooltip("True if it can pass through an enemy")]
    [SerializeField]
    bool isPiercing;

    [Tooltip("How fast this bullet travels")]
    [SerializeField]
    float speed;

    [Tooltip("How long this bullet lasts")]
    [SerializeField]
    float lifetime;

    public int Damage { get => damage; }

    public bool IsPiercing { get => isPiercing; }
    public float Speed { get => speed; }
    public float Lifetime { get => lifetime; }
}
