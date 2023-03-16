using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Item/Item", order = 0)]
public sealed class ItemSO : ScriptableObject
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

    public bool IsKeyItem { get => isKeyItem; }
    
    [SerializeField]
    bool addToInventory = true;

    public bool AddToInventory => addToInventory;

    [SerializeField]
    ItemEffectSO[] _onPickupEffects;

    public ICollection<IItemEffect> OnPickupEffects => _onPickupEffects;    
}
