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
    float speed;

    public int Damage { get => damage; }

    public bool IsPiercing { get => isPiercing; }
    public float Speed { get => speed; }
}
