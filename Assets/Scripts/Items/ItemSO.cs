using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    string itemName;

    public string ItemName { get => itemName; }

    [TextArea]
    [SerializeField]
    string description;

    public string Description { get => description; }

    [Tooltip("Key items are limited to one per inventory")]
    [SerializeField]
    bool isKeyItem;

    /// <summary>
    /// Key items are limited to one per inventory
    /// </summary>
    /// <value></value>
    public bool IsKeyItem { get => isKeyItem; }
}
