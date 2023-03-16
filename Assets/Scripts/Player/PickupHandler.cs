using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    [SerializeField] RuntimeInventory _inventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        var pickupInfo = other.GetComponent<PickupItemInfo>();

        if (pickupInfo == null)
        {
            return;
        }

        // Apply Effects for each item picked up
        pickupInfo.Item.OnPickupEffects.ToList().ForEach(effect => effect.Apply());

        // Add to inventory each item that should be added
        if (pickupInfo.Item.AddToInventory)
        {
            _inventory.ChangeItemCount(pickupInfo.Item, pickupInfo.ItemAmount);
        }
        
        pickupInfo.OnPickup?.Invoke();

        Destroy(other.gameObject);
    }
}
