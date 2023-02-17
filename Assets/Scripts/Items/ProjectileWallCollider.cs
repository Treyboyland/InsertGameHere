using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWallCollider : MonoBehaviour
{
    [SerializeField]
    Projectile projectile;

    public Projectile Projectile { get => projectile; }
}
