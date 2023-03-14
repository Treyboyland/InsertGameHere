using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rho
{
    public class ExternalVariable<T> : ScriptableObject
    {
        #region Value
        [SerializeField, HideInInspector] protected T _value;
        public T Value
        {
            get => _value;
            set 
            {
                var old = _value;
                _value = value;
                Changed(this, old, _value);
            }
        }
        #endregion

        #region Events
        public delegate void ExternalVariableEventHandler(ExternalVariable<T> sender, T oldValue, T newValue);
        public event ExternalVariableEventHandler Changed = delegate {};
        #endregion
    }
}