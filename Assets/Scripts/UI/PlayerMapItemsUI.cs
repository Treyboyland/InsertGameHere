using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapItemsUI : MonoBehaviour
{
    [SerializeField]
    GameObject coinUI;

    [SerializeField]
    GameObject cartridgeUI;

    [SerializeField]
    PlayerInventory inventory;

    [SerializeField]
    ItemSO coinItem;

    [SerializeField]
    ItemSO cartridgeItem;


    // Start is called before the first frame update
    void Start()
    {
        CheckInventory();
    }

    public void CheckInventory()
    {
        cartridgeUI.gameObject.SetActive(inventory.HasItem(cartridgeItem));
        coinUI.gameObject.SetActive(inventory.HasItem(coinItem));
    }
}
