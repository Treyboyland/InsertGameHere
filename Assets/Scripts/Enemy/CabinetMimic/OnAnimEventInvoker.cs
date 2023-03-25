using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAnimEventInvoker : MonoBehaviour
{
    [SerializeField] string _requiredParamterValue;
    [SerializeField] UnityEvent _callback;    
    
    void OnJumpComplete(string parameter)
    {
        if (string.Equals(parameter, _requiredParamterValue))
        {
            _callback.Invoke();
        }
    }
}
