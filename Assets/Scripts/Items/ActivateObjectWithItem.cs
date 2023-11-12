using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectWithItem : MonoBehaviour
{
    [SerializeField]
    GameObject objectToActivate;

    [SerializeField]
    RuntimeInventory playerInventory;

    [SerializeField]
    ItemSO itemToCheck;

    [SerializeField]
    int count;

    // Start is called before the first frame update
    void Start()
    {
        CheckActivation();
    }

    public void CheckActivation()
    {
        objectToActivate.SetActive(playerInventory.HasItem(itemToCheck) && playerInventory.GetItemCount(itemToCheck) >= count);
    }
}
