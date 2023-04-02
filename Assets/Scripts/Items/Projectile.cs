using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    ProjectileStatsSO stats;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    DisableAfterTime disabler;

    public rho.RuntimeGameObjectSet OwnerSet { get; set; }

    [Header("Directions")]
    [SerializeField]
    DirectionSO up;
    [SerializeField]
    DirectionSO down;
    [SerializeField]
    DirectionSO left;
    [SerializeField]
    DirectionSO right;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        disabler.SecondsToWait = stats.Lifetime;
    }

    void DisableIfNotPiercing()
    {
        if (!stats.IsPiercing)
        {
            DisableProjectile();
        }
    }

    public void DisableProjectile()
    {
        disabler.CallDisabledEvent();
        gameObject.SetActive(false);
    }

    void DamgeIfDamageable(Collider2D other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(stats.Damage);
            DisableIfNotPiercing();
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!OwnerSet.Contains(other.gameObject))
        {
            DamgeIfDamageable(other);
        }
    }

    /// <summary>
    /// Fires in one of the given directions
    /// </summary>
    /// <param name="directionSO"></param>
    public void SetDirection(DirectionSO directionSO)
    {
        if (directionSO == up)
        {
            body.velocity = new Vector2(0, stats.Speed);
        }
        else if (directionSO == down)
        {
            body.velocity = new Vector2(0, -stats.Speed);
        }
        else if (directionSO == left)
        {
            body.velocity = new Vector2(-stats.Speed, 0);
        }
        else if (directionSO == right)
        {
            body.velocity = new Vector2(stats.Speed, 0);
        }
    }

    /// <summary>
    /// Fires in the given direction
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
    {
        direction *= stats.Speed;
        body.velocity = direction;
    }
}
