using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CabinetMimicAnimationEventListener : MonoBehaviour
{
    [SerializeField] UnityEvent _onTransformationComplete;
    [SerializeField] UnityEvent _onJumpComplete;

    public void OnTransformationComplete() => _onTransformationComplete.Invoke();

    public void OnJumpComplete() => _onJumpComplete.Invoke();

    [SerializeField] Animator _animator;
    [SerializeField, NaughtyAttributes.AnimatorParam("_animator", AnimatorControllerParameterType.Bool)] 
    string _eatingParam;
    public void SetEatingPlayerFlag(bool value) => _animator.SetBool(_eatingParam, value);
}
