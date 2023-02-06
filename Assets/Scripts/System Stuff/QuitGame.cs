using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{
    public void HandleQuit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //TODO: If cabinet, probably don't want this
            Application.Quit();
        }
    }
}
