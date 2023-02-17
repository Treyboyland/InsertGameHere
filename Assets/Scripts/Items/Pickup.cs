using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    PlayerInventory.InventorySlot itemData;

    [Tooltip("Use for specific events on this item")]
    [SerializeField]
    GameEvent onPickup;

    [Tooltip("Use for the general pickup event")]
    [SerializeField]
    GameEventItemSO onPickupGeneral;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        var inventory = other.gameObject.GetComponent<PlayerInventory>();

        if (inventory)
        {
            inventory.AddItem(itemData);
            onPickup?.Invoke();

            if (onPickupGeneral)
            {
                onPickupGeneral.Value = itemData.Item;
                onPickupGeneral?.Invoke();
            }
            gameObject.SetActive(false);
        }
    }
}
