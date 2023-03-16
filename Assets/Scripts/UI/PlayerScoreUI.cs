using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    ItemSO scoreItem;

    [SerializeField]
    RuntimeInventory _inventory;

    private void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        textBox.text = "" + _inventory.GetItemCount(scoreItem);
    }
}
