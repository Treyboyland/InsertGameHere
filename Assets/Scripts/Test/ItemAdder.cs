using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdder : MonoBehaviour
{
    [SerializeField] RuntimeInventory _inventory;
    [SerializeField] ItemSO _item;
    [SerializeField] int _amount;

    [NaughtyAttributes.Button]
    public void Add()
    {
        _inventory.ChangeItemCount(_item, _amount);
    }
}
