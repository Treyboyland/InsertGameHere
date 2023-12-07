using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "DropTableSO", menuName = "Item/Drop Table", order = 1)]
public class DropTableSO : DropTableAbstract
{
    [SerializeField]
    private List<ItemWeight> itemWeight;

    public override GameObject GetGameObject()
    {
        return itemWeight.GetItem().Item;
    }
}
