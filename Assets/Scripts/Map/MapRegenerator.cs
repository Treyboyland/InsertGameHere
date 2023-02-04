using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapRegenerator : MonoBehaviour
{
    [SerializeField]
    GameMapCreator mapGenerator;

    public void HandleRegeneration(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mapGenerator.GenerateGameMap();
        }
    }
}
