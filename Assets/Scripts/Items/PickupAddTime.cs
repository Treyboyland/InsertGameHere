using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAddTime : MonoBehaviour
{
    [SerializeField]
    ItemTimeAddSO itemData;

    [Tooltip("Use for specific events on this item")]
    [SerializeField]
    GameEvent onPickup;

    [Tooltip("Use for the general pickup event")]
    [SerializeField]
    GameEventItemSO onPickupGeneral;

    [Tooltip("Add time event")]
    [SerializeField]
    GameEventFloat onAddTime;

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
            inventory.AddItem(itemData, 1);
            onPickup?.Invoke();

            if (onPickupGeneral)
            {
                onPickupGeneral.Value = itemData;
                onPickupGeneral?.Invoke();
            }
            if (onAddTime)
            {
                onAddTime.Value = itemData.TimeToAdd;
                onAddTime.Invoke();
            }
            gameObject.SetActive(false);
        }
    }
}
