using UnityEngine;

namespace rho
{
    /// <summary>
    /// A Config Value is a value that is supposed to be set only during editing and then only read during runtime.
    /// Examples: Max Player Lives, Starting Round Timer.
    /// For values that are only used during runtime, use RuntimeValues
    /// </summary>
    public abstract class ConfigValue<T> : ScriptableObject
    {
        [SerializeField] protected T _value;
        public T Value { get => _value; }
    }
}