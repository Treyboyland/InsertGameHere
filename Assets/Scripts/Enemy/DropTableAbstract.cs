using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropTableAbstract : ScriptableObject
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

    public abstract GameObject GetGameObject();
}
