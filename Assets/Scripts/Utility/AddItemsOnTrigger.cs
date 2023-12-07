using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemsOnTrigger : MonoBehaviour
{
    [SerializeField] List<ItemAndCount> items;

    [SerializeField] RuntimeInventory inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            items.ForEach(x => inventory.ChangeItemCount(x.Item, x.Count));
        }
    }
}
