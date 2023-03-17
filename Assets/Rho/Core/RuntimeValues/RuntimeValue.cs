using UnityEngine;

namespace rho
{
    /// <summary>
    /// Runtime Values are values designed to be modifed and read from only during runtime.
    /// These fields are not serialized and therfore should not be edited during editing time.
    /// Example: Player Health, Round time remaining.
    /// For values that are only modified during editing, use ConfigValues.
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
}