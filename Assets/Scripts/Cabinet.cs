using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cabinet : MonoBehaviour
{
    [SerializeField]
    List<InventorySlot> itemsToCheck;

    [SerializeField]
    GameEvent onCabinetPassed;

    [SerializeField]
    GameEvent onPassSound;

    [SerializeField]
    GameEvent onFailSound;

    [SerializeField]
    RuntimeGameObject _playerRef;

    [SerializeField]
    RuntimeInventory _inventory;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != _playerRef.Value)
        {
            return;
        }

        bool hasItems = HasNeededItems();

        if (hasItems)
        {
            onPassSound?.Invoke();
            onCabinetPassed.Invoke();
        }
        else
        {
            onFailSound?.Invoke();
        }
    }


    public bool HasNeededItems()
    {
        return itemsToCheck.All(invSlot => _inventory.HasItems(invSlot.Item, invSlot.Count));
    }
}
