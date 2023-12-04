using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponCircleFire : EnemyWeaponFire
{
    [SerializeField] float degreesPerSecond;

    [SerializeField] float secondsBetweenBullets;

    [SerializeField] List<float> fireAngles;

    public void Fire(float elapsed)
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        var vector = (player.transform.position - enemy.transform.position).normalized;
        foreach (var angle in fireAngles)
        {
            float addition = degreesPerSecond * elapsed;
            var fireVector = Quaternion.AngleAxis(angle + addition, Vector3.forward) * vector;
            SpawnProjectle(fireVector);
        }
    }

    public void ContinousFire(float secondsToFire)
    {
        StartCoroutine(FireForTime(secondsToFire));
    }



    public IEnumerator FireForTime(float seconds)
    {
        float totalElapsed = 0;

        //This is nasty, but IEnumerators do not allow for refs
        IEnumerator WaitForTime(float waitTime)
        {
            float elapsed = 0;
            while (elapsed < waitTime && totalElapsed < seconds)
            {
                yield return null;
                elapsed += Time.deltaTime;
                totalElapsed += Time.deltaTime;
            }
        }

        while (totalElapsed < seconds)
        {
            Fire(totalElapsed);
            yield return StartCoroutine(WaitForTime(secondsBetweenBullets));
        }
    }
}
