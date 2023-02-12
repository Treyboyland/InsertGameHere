using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableProjectilesOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var projectile = other.gameObject.GetComponent<Projectile>();

        if (projectile)
        {
            //Destroy?
            projectile.DisableProjectile();
        }
    }
}
