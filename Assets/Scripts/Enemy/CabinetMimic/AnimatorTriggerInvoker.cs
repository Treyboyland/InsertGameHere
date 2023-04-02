using UnityEngine;

public class AnimatorTriggerInvoker : MonoBehaviour
{
    [SerializeField, NaughtyAttributes.Required]
    Animator _animator;

    [SerializeField, NaughtyAttributes.AnimatorParam("_animator", AnimatorControllerParameterType.Trigger)]
    string _trigger;

    public void Invoke()
    {
        _animator.SetTrigger(_trigger);
    }
}
