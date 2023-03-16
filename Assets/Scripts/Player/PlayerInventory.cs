using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    List<InventorySlot> initialInventory;

    Dictionary<ItemSO, int> inventory = new Dictionary<ItemSO, int>();

    [SerializeField]
    GameEvent inventoryUpdated;


    private void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        foreach (var slot in initialInventory)
        {
            AddItem(slot);
        }
    }

    public void AddItem(InventorySlot slot)
    {
        AddItem(slot.Item, slot.Count);
    }

    /// <summary>
    /// Adds item to inventory
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void AddItem(ItemSO item, int count)
    {
        if (!inventory.ContainsKey(item))
        {
            inventory.Add(item, 0);
        }

        inventory[item] += count;

        //Seems a bit clunky
        if (item.IsKeyItem)
        {
            inventory[item] = 1;
        }
        FireUpdateEvent();
    }

    /// <summary>
    /// True if item in inventory
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool HasItem(ItemSO item)
    {
        return HasItem(item, 1);
    }

    /// <summary>
    /// True if there are at least count items in inventory
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool HasItem(ItemSO item, int count)
    {
        if (!inventory.ContainsKey(item))
        {
            return false;
        }

        return inventory[item] >= count;
    }

    /// <summary>
    /// Removes an item
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(ItemSO item)
    {
        RemoveItem(item, 1);
    }

    /// <summary>
    /// Removes count items from inventory
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    public void RemoveItem(ItemSO item, int count)
    {
        if (!inventory.ContainsKey(item))
        {
            Debug.LogWarning("Inventory doesn't contain item: " + item.ItemName);
            return;
        }

        inventory[item] -= count;

        if (inventory[item] < 0)
        {
            inventory.Remove(item);
        }
        FireUpdateEvent();
    }

    /// <summary>
    /// Returns number of items in inventory
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int GetItemCount(ItemSO item)
    {
        return HasItem(item) ? inventory[item] : 0;
    }

    /// <summary>
    /// Remove All of an item in the inventory
    /// </summary>
    /// <param name="item"></param>
    public void RemoveAll(ItemSO item)
    {
        if (HasItem(item))
        {
            RemoveItem(item, GetItemCount(item));
        }
    }

    public void ClearInventory()
    {
        inventory.Clear();
        Initialize();
        FireUpdateEvent();
    }

    void FireUpdateEvent()
    {
        if (inventoryUpdated)
        {
            inventoryUpdated.Invoke();
        }
    }
}
