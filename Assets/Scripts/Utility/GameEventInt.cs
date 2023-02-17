using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event/Int Event")]
public class GameEventInt : ScriptableObject
{
    List<GameEventListenerInt> listeners = new List<GameEventListenerInt>();

    public int Value;

    public void AddListener(GameEventListenerInt listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(GameEventListenerInt listener)
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
