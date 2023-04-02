using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class CabinetMimicAnimationEventListener : MonoBehaviour
{
    [SerializeField] UnityEvent _onTransformationComplete;
    [SerializeField] UnityEvent _onJumpComplete;
    [SerializeField] UnityEvent _onSpitOutAnimComplete;

    public void OnTransformationComplete() => _onTransformationComplete.Invoke();
    public void OnJumpComplete() => _onJumpComplete.Invoke();
    public void OnSpitOutAnimComplete() => _onSpitOutAnimComplete.Invoke();
}
