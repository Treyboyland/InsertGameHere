using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using rho;

public class Cabinet : MonoBehaviour
{
    [SerializeField]
    List<InventorySlot> itemsToCheck;

    [SerializeField]
    GameEvent onCabinetPassed;

    [SerializeField]
    GameEvent onPassSound;

    [SerializeField]
    GameEvent onFailSound;

    [SerializeField]
    RuntimeGameObject _playerRef;

    [SerializeField]
    RuntimeInt currentLevel;

    [SerializeField]
    List<ItemSO> gameCartridges;

    [SerializeField]
    bool randomizeCartridgeDrop;

    [SerializeField]
    RuntimeInventory _inventory;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != _playerRef.Value)
        {
            return;
        }

        bool hasItems = HasNeededItems();

        if (hasItems)
        {
            if(currentLevel != null)
            {
                AddCartridgeToInventory();
            }
            onPassSound?.Invoke();
            onCabinetPassed.Invoke();
        }
        else
        {
            onFailSound?.Invoke();
        }
    }


    public bool HasNeededItems()
    {
        return itemsToCheck.All(invSlot => _inventory.HasItems(invSlot.Item, invSlot.Count));
    }

    void AddCartridgeToInventory()
    {
        List<ItemSO> possibleCartriges = new List<ItemSO>();

        if(ConfigManager.Manager.CurrentConfiguration.EasyCartridgeAcquiring)
        {
            foreach(var cartridge in gameCartridges)
            {
                if(!_inventory.HasItem(cartridge))
                {
                    possibleCartriges.Add(cartridge);
                }
            }
        }
        else
        {
            possibleCartriges.AddRange(gameCartridges);
        }

        if(possibleCartriges.Count == 0)
        {
            return;
        }

        if (randomizeCartridgeDrop)
        {
            _inventory.AddItem(possibleCartriges.RandomItem());
        }
        else
        {
            ItemSO toAdd;
            if (currentLevel.Value < 0)
            {
                toAdd = gameCartridges[0];
            }
            else if (currentLevel.Value >= gameCartridges.Count)
            {
                toAdd = gameCartridges[gameCartridges.Count - 1];
            }
            else
            {
                toAdd = gameCartridges[currentLevel.Value];
            }

            _inventory.AddItem(toAdd);
        }
    }
}
