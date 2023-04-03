using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnableObjectItemCheck : MonoBehaviour
{
    [SerializeField]
    List<InventorySlot> itemsToCheck;

    [Tooltip("True if object should be enabled if check passed. False if object should be disable if check passed")]
    [SerializeField]
    bool enableObject;

    [SerializeField]
    GameObject objectToEnable;

    [SerializeField]
    RuntimeInventory _inventory;

    public void CheckForItems()
    {
        if (objectToEnable == null)
        {
            return;
        }
        
        bool hasItems = itemsToCheck.All(invSlot => _inventory.HasItems(invSlot.Item, invSlot.Count));

        if (enableObject)
        {
            objectToEnable.SetActive(hasItems);
        }
        else
        {
            objectToEnable.SetActive(!hasItems);
        }
    }
}
