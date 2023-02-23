using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event/Float Event")]
public class GameEventFloat : ScriptableObject
{
    List<GameEventListenerFloat> listeners = new List<GameEventListenerFloat>();

    public float Value;

    public void AddListener(GameEventListenerFloat listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(GameEventListenerFloat listener)
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
