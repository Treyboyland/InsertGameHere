using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameEventListenerCallbackContext : MonoBehaviour
{
    [SerializeField]
    GameEventCallbackContext gameEvent;

    public UnityEvent<InputAction.CallbackContext> Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}
