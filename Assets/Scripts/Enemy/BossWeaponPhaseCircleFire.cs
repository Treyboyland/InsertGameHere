using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponPhaseCircleFire : EnemyFireOnPhase
{
    [SerializeField]
    float secondsToFire;

    public override void Fire()
    {
        if (weapon is BossWeaponCircleFire)
        {
            ((BossWeaponCircleFire)weapon).ContinousFire(secondsToFire);
        }
    }
}
