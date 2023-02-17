using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisableAfterPlaying : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy && particle)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        particle.Play();

        while (particle.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
