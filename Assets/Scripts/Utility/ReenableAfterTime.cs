using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReenableAfterTime : MonoBehaviour
{
    [SerializeField] private GameObject toActivate;

    [SerializeField] private float secondsToWait;

    [SerializeField] private bool checkForItems;

    [SerializeField] private List<ItemAndCount> items;

    [SerializeField]
    RuntimeInventory inventory;

    bool wasReactivated;

    public bool WasReactivated => wasReactivated;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!toActivate.activeInHierarchy)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= secondsToWait && (!checkForItems || !inventory.HasItems(items)))
            {
                toActivate.SetActive(true);
                wasReactivated = true;
            }
        }
        else
        {
            elapsed = 0;
        }
    }
}
