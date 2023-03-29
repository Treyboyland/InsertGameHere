using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SOStateHandler<T> : MonoBehaviour where T : ScriptableObject
{
    [Serializable]
    public class StateCallbackInfo
    {
        public T Value;
        public UnityEvent OnEnter;
        public UnityEvent OnExit;
    }

    [SerializeField] T _initialValue;
    [SerializeField] StateCallbackInfo[] _transitionEvents;
    
    protected T _state;
    public T State 
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
