using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Game/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    string itemName;

    public string ItemName { get => itemName; }

    [TextArea]
    [SerializeField]
    string description;

    public string Description { get => description; }

    [SerializeField]
    bool isKeyItem;

    public bool IsKeyItem { get => isKeyItem; }
}
