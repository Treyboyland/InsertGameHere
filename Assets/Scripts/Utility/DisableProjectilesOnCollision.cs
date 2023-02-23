using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableProjectilesOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var projectile = other.gameObject.GetComponent<ProjectileWallCollider>();
        var projectileOther = other.gameObject.GetComponent<Projectile>();
        //Debug.LogWarning("Wall Hit");

        if (projectile)
        {
            //Destroy?
            projectile.Projectile.DisableProjectile();
        }
        else if (projectileOther)
        {
            projectileOther.DisableProjectile();
        }
    }
}
