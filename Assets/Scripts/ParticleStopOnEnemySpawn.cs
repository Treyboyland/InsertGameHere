using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStopOnEnemySpawn : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    public Enemy Enemy { get; set; }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        if (Enemy == null || Enemy.gameObject.activeInHierarchy)
        {
            yield break;
        }

        particle.Play();

        while (!Enemy.gameObject.activeInHierarchy)
        {
            yield return null;
        }

        particle.Stop();

        while (particle.particleCount != 0)
        {
            yield return null;
        }


    }
}
