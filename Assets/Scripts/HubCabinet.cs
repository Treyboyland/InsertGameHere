using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubCabinet : MonoBehaviour
{
    [SerializeField]
    HubCabinetDataSO cabinetData;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameEventItemSO onPlayerEnter;

    [SerializeField]
    GameEvent onPlayerExit;

    [SerializeField] RuntimeInventory inventory;

    ItemSO itemDataToUse;

    private void Start()
    {
        SetCabinetState();
    }

    void SetCabinetState()
    {
        if (!inventory)
        {
            SetCabinetInactive();
        }
        else
        {
            if (inventory.HasItem(cabinetData.CabinetData))
            {
                SetCabinetActive();
            }
            else
            {
                SetCabinetInactive();
            }
        }
    }

    void SetCabinetInactive()
    {
        spriteRenderer.sprite = cabinetData.InactiveSprite;
        itemDataToUse = cabinetData.InactiveCabinetData;
    }

    void SetCabinetActive()
    {
        spriteRenderer.sprite = cabinetData.ActiveSprite;
        itemDataToUse = cabinetData.CabinetData;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player && onPlayerEnter)
        {
            onPlayerEnter.Value = itemDataToUse;
            onPlayerEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player)
        {
            onPlayerExit.Invoke();
        }
    }
}
