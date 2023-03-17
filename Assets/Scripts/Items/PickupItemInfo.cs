using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemInfo : MonoBehaviour
{
    public ItemSO Item;
    public int ItemAmount = 1;

    [Tooltip("Use for specific events on this item")]
    public GameEvent OnPickup;
}
