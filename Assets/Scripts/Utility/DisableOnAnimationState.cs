using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnAnimationState : MonoBehaviour
{
    [SerializeField]
    string stateToDisableOn;

    [SerializeField]
    Animator animator;


    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        yield return StartCoroutine(animator.WaitForState(stateToDisableOn));
    }
}
