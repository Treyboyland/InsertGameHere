using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTowardsPlayerSquare : EnemyMove
{
    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    bool takeShorterFirst;

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

    Vector3 GetMoveVector(Vector3 x, Vector3 y)
    {
        if (takeShorterFirst)
        {
            return x.sqrMagnitude > y.sqrMagnitude ? y : x;
        }
        else
        {
            return x.sqrMagnitude > y.sqrMagnitude ? x : y;
        }
    }

    void MovementAction()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 directionX = Vector3.zero;
        Vector3 directionY = Vector3.zero;
        directionX.x = direction.x;
        directionY.y = direction.y;

        Vector3 useDirection = GetMoveVector(directionX, directionY);

        useDirection *= enemy.Stats.Speed;

        body.velocity = Vector2.zero;

        body.AddForce(useDirection, ForceMode2D.Impulse);

    }


}
