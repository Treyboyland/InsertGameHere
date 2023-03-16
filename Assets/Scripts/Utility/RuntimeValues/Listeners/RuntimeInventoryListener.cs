using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RuntimeInventoryListener : MonoBehaviour
{
    [SerializeField] RuntimeInventory _inventory;
    [SerializeField] UnityEvent _callback;

    virtual protected void OnEnable()
    {
        _inventory.Changed += OnValueChanged;
    }

    virtual protected void OnDisable()
    {
        _inventory.Changed -= OnValueChanged;            
    }

    virtual protected void OnValueChanged()
    {
        _callback.Invoke();
    }
}
