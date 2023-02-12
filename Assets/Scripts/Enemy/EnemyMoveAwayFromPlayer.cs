using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAwayFromPlayer : EnemyMove
{
    [SerializeField]
    Rigidbody2D body;

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
        if (!player)
        {
            return;
        }

        var distance = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (distance < enemy.Stats.DistanceFromPlayer)
        {
            Vector3 direction = (enemy.transform.position - player.transform.position).normalized;
            direction *= enemy.Stats.Speed;
            body.AddForce(direction, ForceMode2D.Impulse);
        }
    }
}
