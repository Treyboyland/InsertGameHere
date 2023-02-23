using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "DropTableSO", menuName = "Item/Drop Table", order = 1)]
public class DropTableSO : ScriptableObject
{
    [Serializable]
    public struct ItemWeight
    {
        /// <summary>
        /// Item to Spawn
        /// </summary>
        [Tooltip("Item to drop")]
        public GameObject Item;
        /// <summary>
        /// Weight of the item in the table
        /// </summary>
        [Tooltip("Weight of this item in the table")]
        public int Weight;
    }

    [SerializeField]
    List<ItemWeight> itemWeight;

    public GameObject GetGameObject()
    {
        int total = itemWeight.Select(x => x.Weight).Sum();
        int current = 0;
        int randomValue = UnityEngine.Random.Range(0, total);

        foreach (var item in itemWeight)
        {
            current += item.Weight;
            if (randomValue < current)
            {
                return item.Item;
            }
        }

        return itemWeight[itemWeight.Count - 1].Item;
    }
}
