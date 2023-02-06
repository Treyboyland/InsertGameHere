using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(DisableAfterPlay());
        }
    }

    IEnumerator DisableAfterPlay()
    {
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
