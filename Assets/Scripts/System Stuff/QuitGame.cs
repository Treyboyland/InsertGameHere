using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{
    [SerializeField]
    GameEvent onForceTimeout;

    public void HandleQuit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //TODO: If cabinet, probably don't want this
            if (ConfigManager.Manager != null)
            {
                if (ConfigManager.Manager.CurrentConfiguration.IsArcadeCabinet || ConfigManager.Manager.CurrentConfiguration.PreventExiting)
                {
                    if (onForceTimeout != null)
                    {
                        onForceTimeout.Invoke();
                    }
                }
                else
                {
                    Application.Quit();
                }
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
