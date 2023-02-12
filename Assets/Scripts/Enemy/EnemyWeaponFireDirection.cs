using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponFireDirection : EnemyWeaponFire
{
    [SerializeField]
    List<Vector2> directions;

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
        foreach (var direction in directions)
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

            projectile.Owner = enemyOwner;
            projectile.transform.position = transform.position;
            projectile.transform.SetParent(null);
            projectile.gameObject.SetActive(true);
            projectile.SetDirection(direction.normalized);
        }
    }
}
