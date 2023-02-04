using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour
{
    [SerializeField]
    List<PlayerInventory.InventorySlot> itemsToCheck;

    [SerializeField]
    GameEvent onCabinetPassed;

    bool HasItems(PlayerInventory inventory)
    {
        foreach (var slot in itemsToCheck)
        {
            if (!inventory.HasItem(slot.Item, slot.Count))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory inventory = other.gameObject.GetComponent<PlayerInventory>();

        if (inventory && HasItems(inventory))
        {
            onCabinetPassed.Invoke();
        }
    }
}
