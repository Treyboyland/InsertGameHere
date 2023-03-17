using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace rho
{
    /// <summary>
    /// If the runtime set changes, invoke the onChange UnityEvent.
    /// </summary>
    public class GameObjectSetChangeListener : MonoBehaviour
    {
        [SerializeField] RuntimeGameObjectSet _runtimeSet = null;
        [SerializeField] UnityEvent<RuntimeGameObjectSet> _onChange;

        void SetChanged(RuntimeSet<GameObject> sender)
        {
            _onChange.Invoke(_runtimeSet);
        }

        void OnEnable()
        {
            _runtimeSet.SetChanged += SetChanged;
        }

        void OnDisable()
        {
            _runtimeSet.SetChanged -= SetChanged;
        }
    }
}