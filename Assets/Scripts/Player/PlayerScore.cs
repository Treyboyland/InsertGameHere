using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    PlayerInventory inventory;

    [SerializeField]
    ItemSO scoreItem;

    public void AddScore(int score)
    {
        inventory.AddItem(scoreItem, score);
    }

    public void RemoveScore(int score)
    {
        inventory.RemoveItem(scoreItem, score);
    }
}
