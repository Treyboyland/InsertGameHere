using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Game Event/VectorInt Event")]
public class GameEventVectorInt : ScriptableObject
{
    List<GameEventListenerVectorInt> listeners = new List<GameEventListenerVectorInt>();

    public Vector3Int Value;

    public void AddListener(GameEventListenerVectorInt listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(GameEventListenerVectorInt listener)
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
