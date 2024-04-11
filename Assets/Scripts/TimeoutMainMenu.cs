using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class TimeoutMainMenu : MonoBehaviour
{
    [SerializeField]
    RuntimeInventory playerInventory;

    [SerializeField]
    List<ItemSO> cabinetCartridges;

    [SerializeField]
    GameEvent loadTitle;

    float secondsToWait;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        InputSystem.onAnyButtonPress.Call(unused => ResetTime());
        secondsToWait = ConfigManager.Manager.CurrentConfiguration.IdleTimeout;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= secondsToWait && ConfigManager.Manager.CurrentConfiguration.IsArcadeCabinet)
        {
            if (ConfigManager.Manager.CurrentConfiguration.WipeCartridgesOnTitleScreen)
            {
                ClearCartridges();
            }
            loadTitle.Invoke();
        }
    }

    void ClearCartridges()
    {
        foreach (var item in cabinetCartridges)
        {
            playerInventory.ClearItem(item);
        }
    }

    public void ResetTime()
    {
        elapsed = 0;
    }
}
