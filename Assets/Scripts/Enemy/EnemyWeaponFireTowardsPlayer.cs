using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponFireTowardsPlayer : EnemyWeaponFire
{
    float elapsed = 0;

    private void Update()
    {
        if (ShouldPerformAction())
        {
            FireAction();
        }
    }

    void FireAction()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= enemy.Stats.FireRate)
        {
            elapsed = 0;
            Fire();
        }
    }

    void Fire()
    {
        var obj = bulletPool.GetObject();
        if (!obj)
        {
            return;
        }

        Projectile projectile = obj.GetComponent<Projectile>();
        if (!projectile)
        {
            return;

        }

        Vector3 direction = (player.transform.position - enemy.transform.position).normalized;

        projectile.Owner = enemyOwner;
        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(true);
        projectile.transform.SetParent(null);
        projectile.SetDirection(direction);
    }
}
