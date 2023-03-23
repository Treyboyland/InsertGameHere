using UnityEngine;
using UnityEngine.Events;

public class OnTransformationCompleteListener : MonoBehaviour
{
    [SerializeField]
    UnityEvent _callback;

    public void OnTransformationComplete()
    {
        _callback.Invoke();
    }
}
