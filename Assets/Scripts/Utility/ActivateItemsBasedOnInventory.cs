using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateItemsBasedOnInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsActiveOnSuccess;

    [SerializeField] private List<GameObject> objectsActiveOnFailure;

    [SerializeField] private List<ItemAndCount> items;

    [SerializeField] RuntimeInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        RunCheck();
    }

    bool HasAllItems()
    {
        foreach (var itemCount in items)
        {
            if (!inventory.HasItems(itemCount.Item, itemCount.Count))
            {
                return false;
            }
        }

        return true;
    }

    public void RunCheck()
    {  
        var success = HasAllItems();
        objectsActiveOnSuccess?.ForEach(x => x.SetActive(success));
        objectsActiveOnFailure?.ForEach(x => x.SetActive(!success));
    }
}
