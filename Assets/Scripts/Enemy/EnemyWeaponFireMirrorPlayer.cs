using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponFireMirrorPlayer : EnemyWeaponFire
{
    public void FireProjectile(DirectionSO playerFire)
    {
        if (ShouldPerformAction())
        {
            SpawnProjectle(playerFire.Opposite);
        }
    }
}
