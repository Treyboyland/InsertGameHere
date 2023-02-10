using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTowardsPlayer : EnemyMove
{
    [SerializeField]
    Rigidbody2D body;

    float elapsed = 0;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (ShouldPerformAction())
        {
            MovementAction();
        }
    }

    void MovementAction()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= enemy.Stats.SecondsBetweenMove)
        {
            elapsed = 0;
            Vector3 direction = (player.transform.position - transform.position).normalized;
            direction *= enemy.Stats.Speed;

            body.AddForce(direction, ForceMode2D.Impulse);
        }
    }


}
