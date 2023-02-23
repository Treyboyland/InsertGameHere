using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventItem", menuName = "Game Event/Item Event")]
public class GameEventItemSO : ScriptableObject
{
    List<GameEventListenerItemSO> listeners = new List<GameEventListenerItemSO>();

    public ItemSO Value;

    public void AddListener(GameEventListenerItemSO listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(GameEventListenerItemSO listener)
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
