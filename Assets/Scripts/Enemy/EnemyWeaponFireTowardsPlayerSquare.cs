using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponFireTowardsPlayerSquare : EnemyWeaponFire
{
    float elapsed = 0;

    [SerializeField]
    List<float> fireAngles;

    [SerializeField]
    DirectionSO up, down, left, right;

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
        var playervector = (player.transform.position - enemy.transform.position).normalized;

        DirectionSO toUse;

        if (Mathf.Abs(playervector.x) > Mathf.Abs(playervector.y))
        {
            toUse = playervector.x < 0 ? left : right;
            //Debug.LogWarning(playervector.x < 0 ? "Left" : "Right");
        }
        else
        {
            toUse = playervector.y < 0 ? down : up;
            //Debug.LogWarning(playervector.y < 0 ? "Down" : "Up");
        }

        foreach (var angle in fireAngles)
        {
            var fireVector = Quaternion.AngleAxis(angle, Vector3.forward) * toUse.NormalizedVector;

            SpawnProjectle(fireVector);
        }
    }
}
