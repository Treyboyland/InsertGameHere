using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO-TimeAdd-", menuName = "Item/Item Time Add")]
public class ItemTimeAddSO : ItemSO
{
    [SerializeField]
    float timeToAdd;

    public float TimeToAdd { get => timeToAdd; }
}
