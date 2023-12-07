using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponCircleFireAction : MonoBehaviour
{
    [SerializeField]
    BossWeaponCircleFire weapon;

    [SerializeField]
    float secondsToFire;

    float elapsed = 0;

    bool isFiring = false;

    private void OnEnable()
    {
        elapsed = 0;
    }

    private void Update()
    {
        if (weapon.ShouldPerformAction())
        {
            if (!isFiring)
            {
                elapsed += Time.deltaTime;
            }
            FireAction();
        }
    }

    void FireAction()
    {
        if (elapsed > weapon.Enemy.Stats.FireRate)
        {
            elapsed = 0;
            StartCoroutine(DoFire());
        }
    }

    IEnumerator DoFire()
    {
        isFiring = true;
        yield return StartCoroutine(weapon.FireForTime(secondsToFire));
        isFiring = false;
    }
}
