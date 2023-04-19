using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFusionLimit : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    public void DecrementFusionCount()
    {
        EnemyFuseOnCollision.DecrementEnemy(enemy);
    }
}
