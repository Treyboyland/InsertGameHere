using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RuntimeInventoryListener : MonoBehaviour
{
    [SerializeField] RuntimeInventory _inventory;
    [SerializeField] UnityEvent _callback;
    [SerializeField] UnityEvent<ItemSO, int> _itemCountChanged;

    virtual protected void OnEnable()
    {
        _inventory.Changed += OnValueChanged;
        _inventory.ItemCountChanged += OnItemCountChanged;
    }

    virtual protected void OnDisable()
    {
        _inventory.Changed -= OnValueChanged;
        _inventory.ItemCountChanged -= OnItemCountChanged;    
    }

    virtual protected void OnValueChanged()
    {
        _callback.Invoke();
    }

    virtual protected void OnItemCountChanged(ItemSO item, int amount)
    {
        _itemCountChanged.Invoke(item, amount);
    }
}
