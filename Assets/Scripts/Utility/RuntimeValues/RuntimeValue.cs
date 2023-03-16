using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Runtime Values are values designed to be modifed and read from only during runtime.
/// These fields are not serialized and therfore should not be edited during editing time.
/// </summary>
public abstract class RuntimeValue<T> : ScriptableObject
{
    #region Events
    public event System.Action Changed;
    #endregion

    [NaughtyAttributes.ShowNonSerializedField]
    protected T _value;
    
    public T Value
    {
        get => _value;
        set 
        {
            var old = _value;
            _value = value;
            Changed?.Invoke();
        }
    }
}
