using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class StateCallbackInfo
{
    public CabinetMimicState Value;
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
}

public class CabinetMimicStateMachine : MonoBehaviour
{
    [SerializeField] CabinetMimicState _initialValue;
    [SerializeField] StateCallbackInfo[] _transitionEvents;
    
    protected CabinetMimicState _state;
    public CabinetMimicState State 
    { 
        get => _state;
        set
        {
            if (_state == value)
            {
                return;
            }

            var onExitCallbacks = _transitionEvents.Where(info => info.Value == _state).Select(info => info.OnExit);
            var onEnterCallbacks = _transitionEvents.Where(info => info.Value == value).Select(info => info.OnEnter);
            _state = value;
            onExitCallbacks.Union(onEnterCallbacks).ToList().ForEach(callback => callback.Invoke());
        }
    }

    void Start() => _state = _initialValue;
}
