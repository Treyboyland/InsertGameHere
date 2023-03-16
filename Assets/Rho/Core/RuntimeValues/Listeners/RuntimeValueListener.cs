using UnityEngine;
using UnityEngine.Events;

namespace rho
{
    public abstract class RuntimeValueListener<T> : MonoBehaviour
    {
        [SerializeField] RuntimeValue<T> _variable;
        [SerializeField] UnityEvent _callback;

        virtual protected void OnEnable()
        {
            _variable.Changed += OnValueChanged;
        }

        virtual protected void OnDisable()
        {
            _variable.Changed -= OnValueChanged;            
        }

        virtual protected void OnValueChanged()
        {
            _callback.Invoke();
        }
    }
}