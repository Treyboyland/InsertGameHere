using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCountUI : MonoBehaviour
{
    [SerializeField]
    ItemSO itemToTrack;

    [SerializeField]
    TMP_Text textbox;

    [Tooltip("Adds an 'x' to the count")]
    [SerializeField]
    bool addX;

    [SerializeField]
    RuntimeInventory inventory;

    private void Start()
    {
        CheckForItem();
    }

    public void CheckForItem()
    {
        var count = inventory.GetItemCount(itemToTrack);
        textbox.text = (addX ? "x" : "") + count;
    }
}
