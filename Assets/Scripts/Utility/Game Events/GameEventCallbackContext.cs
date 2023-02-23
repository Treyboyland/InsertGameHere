using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event/Callback Context Event")]
public class GameEventCallbackContext : ScriptableObject
{
    List<GameEventListenerCallbackContext> listeners = new List<GameEventListenerCallbackContext>();

    public InputAction.CallbackContext Value;

    public void AddListener(GameEventListenerCallbackContext listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(GameEventListenerCallbackContext listener)
    {
        listeners.Remove(listener);
    }

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke(Value);
        }
    }

    public void HandleCallbackContext(InputAction.CallbackContext context)
    {
        Value = context;
        Invoke();
    }
}
