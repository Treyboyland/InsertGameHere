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
        SpawnProjectle((player.transform.position - enemy.transform.position).normalized);
    }
}
