using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rho
{
    [CreateAssetMenu(menuName = "Rho/Event")]
    public class Event : ScriptableObject
    {
        List<EventListener> _listeners = new List<EventListener>();

        public void Raise(params object[] args)
        {
            for (var i = _listeners.Count - 1; i >= 0 ; --i)
            {
                _listeners[i].OnEventRaised(args);
            }
        }

        /// <summary>
        /// Raise the Event with 0 Arguments.
        /// Use for hooking up simple events in the Inspector, like attaching an Event object in a UnityEvent and setting the Function target as Raise0Arg().
        /// Unity isn't smart enough to see Raise(params ...) as a potentially 0 argument list.
        /// </summary>
        public void Raise0Args() => Raise();

        public void Register(EventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}