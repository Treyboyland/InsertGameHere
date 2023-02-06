using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTowardsPlayer : EnemyMove
{
    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    FloatValueSO secondsBetweenMove;

    [SerializeField]
    FloatValueSO force;

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
        if (elapsed >= secondsBetweenMove)
        {
            elapsed = 0;
            Vector3 direction = (player.transform.position - transform.position).normalized;
            direction *= force;

            body.AddForce(direction, ForceMode2D.Impulse);
        }
    }


}
