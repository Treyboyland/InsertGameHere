using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTowardsPlayerConstant : EnemyMove
{
    [SerializeField]
    float distanceThreshold;

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
            direction *= enemy.Stats.Speed * Time.deltaTime;

            transform.position += direction;
        }
    }

    public override bool ShouldPerformAction()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        return player && (player.transform.position - enemy.transform.position).sqrMagnitude > distanceThreshold;
    }

}
