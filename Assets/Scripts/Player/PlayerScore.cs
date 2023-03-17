using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    RuntimeInventory inventory;

    [SerializeField]
    ItemSO scoreItem;
    
    public void OnDeathEvent(EnemyDeathInfo info)
    {
        inventory.ChangeItemCount(scoreItem, info.Score);
    }
}
