using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event/Normal Event")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke();
        }
    }
}
