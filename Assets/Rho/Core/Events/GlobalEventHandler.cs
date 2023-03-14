using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace rho
{
	// TODO Add a 'slow' unregister so objects can unregister themselves during an event call
	// TODO Throw ArgumentException if the Target of the delegate is not a MonoBehavior
	/// <summary>
	/// Class for handling observable game events.
	/// </summary>
	public static class GlobalEventHandler
	{
		public delegate void GameEventCallback<T>(T evt) where T : IGameEvent;

		// Our pair matching our GameObject and the delegate that is called
		// We need to hold refernece to both so we can test if the GameObject is still alive before calling.
		private class GOCallbackPair
		{
			public GameObject GameObject;
			public object DelegatePtr;

			public GOCallbackPair(GameObject go, object fptr)
			{
				GameObject = go;
				DelegatePtr = fptr;
			}
		}

		/// <summary>
		/// Dictionary with IGameEvent keys associated with a list of valid delegates.
		/// </summary>
		private static Dictionary<Type, List<GOCallbackPair>> _eventList = new Dictionary<Type, List<GOCallbackPair>>();
		
		/// <summary>
		/// Those callbacks that registered to all Game Events
		/// </summary>
		private static List<GOCallbackPair> _allEventListeners = new List<GOCallbackPair>();

		/// <summary>
		/// Iterate over all callbacks in the list and call each with the game event as arg.
		/// </summary>
		private static void CallDelegates<T>(List<GOCallbackPair> list, T evt) where T : IGameEvent
		{
			for (var i = list.Count - 1; i >= 0; i--)
			{
				var e = list[i];
				if (e.GameObject != null) { ((GameEventCallback<T>)e.DelegatePtr)(evt); }
				else { list.Remove(e); }
			}
		}

		/// <summary>
		/// Clear all those registered to events.
		/// Should only really be used in Unit Tests.
		/// </summary>
		public static void Clear()
		{
			_eventList = new Dictionary<Type, List<GOCallbackPair>>();
			_allEventListeners = new List<GOCallbackPair>();
		}

		/// <summary>
		/// Attaches a delegate to a specific IGameEvent.
		/// Example:
		/// GlobalEventHandler.Register<PlayerDeathEvent>(OnPlayerDeathEvent)
		/// ...
		/// public void OnPlayerDeathEvent(PlayerDeathEvent evt){}
		/// </summary>
		/// <param name="evt"></param>
		/// <param name="f"></param>
		public static void Register<T>(GameEventCallback<T> f) where T: IGameEvent
		{
			// First, get the class Type
			Type type = typeof(T);
			
			// If it doesn't exist, add an entry for it
			if (!_eventList.ContainsKey(type))
			{
				_eventList.Add(type, new List<GOCallbackPair>());
			}

			// Add the delegate to the list. The Target is cast explicitly to MonoBehaviour in order to retrieve the GameObject instance
			_eventList[type].Add(new GOCallbackPair(
				((MonoBehaviour)f.Target).gameObject,
				(object)f
			));
		}

        /// <summary>
        /// Attaches a delegate to the BroadcastListener, which listens for all game events.
        /// </summary>
        public static void RegisterAll(GameEventCallback<IGameEvent> f)
        {
            _allEventListeners.Add(new GOCallbackPair(
				((MonoBehaviour)f.Target).gameObject,
				(object)f
			));
        }

        /// <summary>
        /// Removes a delegate from an IGameEvent list, if it exists.
        /// Example:
        /// GlobalEventHandler.Unregister<PlayerDeathEvent>(OnPlayerDeathEvent)
        /// ...
        /// public void OnPlayerDeathEvent(PlayerDeathEvent evt){}
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="f"></param>
        public static void Unregister<T>(GameEventCallback<T> f) where T: IGameEvent
		{
			// Grab the Type and make a temporary Tuple containing all the necessary data
			Type type = typeof(T);

			// Don't bother looking if it doesn't exist
			if (_eventList.ContainsKey(type))
			{
				_eventList[type].RemoveAll(x=>(GameEventCallback<T>) x.DelegatePtr == f);
			}
		}

        /// <summary>
        /// Removes a delegate from the BroadcastListeners, if it exists.
        /// </summary>
        public static void UnregisterAll(GameEventCallback<IGameEvent> f)
        {
            _allEventListeners.RemoveAll(x=>(GameEventCallback<IGameEvent>) x.DelegatePtr == f);
        }

		/// <summary>
		/// Sends the IGameEvent to all delegates attached to it and to the BroadcastListeners.
		/// Example:
		/// GlobalEventHandler.SendEvent(new PlayerDeathEvent())
		/// </summary>
		/// <param name="evt"></param>
		public static void SendEvent<T>(T evt) where T: IGameEvent
		{
			// We make our delegate call on the type of event that's sent
			List<GOCallbackPair> list;			
			if (_eventList.TryGetValue(typeof(T), out list))
				CallDelegates(list, evt);
			
			// Call all registered delegates who registered for all events
			CallDelegates<IGameEvent>(_allEventListeners, evt);
		}
	}
}
