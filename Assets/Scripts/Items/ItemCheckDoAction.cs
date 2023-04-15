using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ItemCheckDoAction : MonoBehaviour
{
    [SerializeField]
    List<InventorySlot> itemsToCheck;

    [SerializeField]
    RuntimeGameObject _playerRef;

    [SerializeField]
    RuntimeInventory _inventory;

    [SerializeField]
    GameEventVector spawnEventOnSuccess;

    public UnityEvent OnSuccess;
    public UnityEvent OnFail;


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
            OnSuccess.Invoke();
            spawnEventOnSuccess.Value = transform.position;
            spawnEventOnSuccess.Invoke();
        }
        else
        {
            OnFail.Invoke();
        }

        if (hasItems)
        {
            gameObject.SetActive(false);
        }
    }

    public bool HasNeededItems()
    {
        return itemsToCheck.All(invSlot => _inventory.HasItems(invSlot.Item, invSlot.Count));
    }

    public void RemoveItems()
    {
        foreach(var slot in itemsToCheck)
        {
            _inventory.ChangeItemCount(slot.Item, -slot.Count);
        }
    }
}
