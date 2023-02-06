using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    PlayerInventory.InventorySlot itemData;

    [SerializeField]
    GameEvent onPickup;

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
            gameObject.SetActive(false);
        }
    }
}
