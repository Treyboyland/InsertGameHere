using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetController : MonoBehaviour
{
    [SerializeField]
    Cabinet normalCabinet;

    [SerializeField]
    Enemy monsterCabinet;

    [SerializeField]
    RuntimeGameObject _playerRef;

    [SerializeField]
    RuntimeInventory _inventory;

    public bool PerformChecks { get; set; }

    private void Start()
    {
        CheckForItems();
    }

    public void CheckForItems()
    {
        if (PerformChecks)
        {
            bool normal = normalCabinet.HasNeededItems() || monsterCabinet.IsDefeated;
            Debug.LogWarning("HAs items: " + normalCabinet.HasNeededItems() + " Enemy Defeated: " + monsterCabinet.IsDefeated);
            SetNormalCabinetActive(normal);
        }
        else
        {
            SetNormalCabinetActive(true);
        }
    }

    void SetNormalCabinetActive(bool setNormalActive)
    {
        normalCabinet.gameObject.SetActive(setNormalActive);
        monsterCabinet.gameObject.SetActive(!setNormalActive);
    }
}
