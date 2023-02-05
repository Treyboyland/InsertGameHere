using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField]
    float secondsToWait;

    public float SecondsToWait { get => secondsToWait; set => secondsToWait = value; }

    [SerializeField]
    GameEventVector disabledAtLocation;

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
        float elapsed = 0;
        while (elapsed < secondsToWait)
        {
            yield return null;
            elapsed += Time.deltaTime;
        }

        if (disabledAtLocation)
        {
            disabledAtLocation.Value = transform.position;
            disabledAtLocation.Invoke();
        }

        gameObject.SetActive(false);
    }
}
