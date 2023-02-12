using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponFire : EnemyMove
{
    [SerializeField]
    protected ObjectPool bulletPool;

    [SerializeField]
    protected OwnerTypeSO enemyOwner;
}
