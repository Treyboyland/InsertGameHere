using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponFireTowardsPlayer : EnemyWeaponFire
{
    [SerializeField] private float secondsBetweenShots;

    private void OnEnable()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
    }

    public void Fire()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        SpawnProjectle((player.transform.position - enemy.transform.position).normalized);
    }

    public void BurstFire(int numToFire)
    {
        StartCoroutine(FireOverTime(numToFire));
    }

    IEnumerator FireOverTime(int numToFire)
    {
        for (int i = 0; i < numToFire; i++)
        {
            Fire();
            yield return new WaitForSeconds(secondsBetweenShots);
        }
    }
}
