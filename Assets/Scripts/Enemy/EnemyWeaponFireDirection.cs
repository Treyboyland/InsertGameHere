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
        if (!manualFire && ShouldPerformAction())
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

    public override void Fire()
    {
        directions.ForEach(SpawnProjectle);
    }
}
