using System.Collections.Generic;
using UnityEngine;

public class ParamterizedGameEvent<T> : ScriptableObject
{
    List<ParamterizedGameEventListener<T>> listeners = new List<ParamterizedGameEventListener<T>>();

    public void AddListener(ParamterizedGameEventListener<T> listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveListener(ParamterizedGameEventListener<T> listener)
    {
        listeners.Remove(listener);
    }

    public void Invoke(T argument)
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke(argument);
        }
    }
}
