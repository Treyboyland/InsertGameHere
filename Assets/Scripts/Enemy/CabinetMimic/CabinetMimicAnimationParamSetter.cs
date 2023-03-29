using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetMimicAnimationParamSetter : MonoBehaviour
{
    [SerializeField] Animator _animator;

    [SerializeField, NaughtyAttributes.AnimatorParam("_animator", AnimatorControllerParameterType.Bool)] 
    string _eatingParam;
    public void SetEatingPlayerFlag(bool value) => _animator.SetBool(_eatingParam, value);

    [SerializeField, NaughtyAttributes.AnimatorParam("_animator", AnimatorControllerParameterType.Trigger)] 
    string _jumpTrigger;
    public void Jump() => _animator.SetTrigger(_jumpTrigger);

    [SerializeField, NaughtyAttributes.AnimatorParam("_animator", AnimatorControllerParameterType.Trigger)] 
    string _stopHidingTrigger;
    public void StopHiding() => _animator.SetTrigger(_stopHidingTrigger);
}
