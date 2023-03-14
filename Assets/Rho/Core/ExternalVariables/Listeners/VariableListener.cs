using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace rho
{
    /// <summary>
    /// Listen for Changes in External Variable and raise an event when value changes.
    /// Optionaly, enable 'Only Raise On Value' to only raise event when variable is set to specified 'Raise On Value'.
    /// </summary>
    public class VariableListener<T> : MonoBehaviour
    {
        [SerializeField] ExternalVariable<T> _variable;
        [SerializeField] UnityEvent<ExternalVariable<T>, T, T> _callback;
        [SerializeField] bool _onlyRaiseOnValue;
        [SerializeField] T _raiseOnValue;

        virtual protected void OnEnable()
        {
            _variable.Changed += OnValueChanged;
        }

        virtual protected void OnDisable()
        {
            _variable.Changed -= OnValueChanged;            
        }

        virtual protected void OnValueChanged(ExternalVariable<T> sender, T oldValue, T newValue)
        {
            if (_onlyRaiseOnValue && !_raiseOnValue.Equals(newValue))
            {
                return;
            }

            _callback.Invoke(sender, oldValue, newValue);
        }
    }
}