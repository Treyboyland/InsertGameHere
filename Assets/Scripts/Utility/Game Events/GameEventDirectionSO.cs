using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventDirection", menuName = "Game Event/Direction Event")]
public class GameEventDirectionSO : ScriptableObject
{
    List<GameEventListenerDirectionSO> listeners = new List<GameEventListenerDirectionSO>();

    public DirectionSO Value;

    public void AddListener(GameEventListenerDirectionSO listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(GameEventListenerDirectionSO listener)
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
