using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event/Vector Event")]
public class GameEventVector : ScriptableObject
{
    List<GameEventListenerVector> listeners = new List<GameEventListenerVector>();

    public Vector3 Value;

    public void AddListener(GameEventListenerVector listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(GameEventListenerVector listener)
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
}
