using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace rho
{
	/// <summary>
	/// Interface that anyone could implement to be able to handle Events
	/// </summary>
	public interface IEventHandler
	{
		void handleEvent( IGameEvent evt );
	}

	/// <summary>
	/// Static EventBroadcaster class ( basically a glorified namespace )
	/// </summary>
	public static class EventBroadcaster 
	{
		/// <summary>
		/// Scary Looking but simple map of event types to registers of said event type.
		/// </summary>
		private static Dictionary< Type, List<IEventHandler> > handlerMap = 
			new Dictionary< Type, List<IEventHandler> >();

		/// <summary>
		/// Register an Event handler for a specific event
		/// </summary>
		public static void registerHandler<TypeEvent>( IEventHandler event_handler ) where TypeEvent : IGameEvent
		{
			Type type = typeof(TypeEvent);

			if ( ! handlerMap.ContainsKey( type ) )		// If we've never seen this event type before
			{
				// Make a new list
				handlerMap[ type ] = new List<IEventHandler>();
			}

			List<IEventHandler> handler_list = handlerMap[ type ];

			if ( ! handler_list.Contains( event_handler ) )		// If we already don't have this handler registered to this event
			{
				handler_list.Add( event_handler );
			}
		}

		/// <summary>
		/// Unregister this handler from everything
		/// </summary>
		public static void unregsterHandler( IEventHandler event_handler )
		{
			// Foreach through this stupid handler map
			foreach ( KeyValuePair< Type, List<IEventHandler> > pair in handlerMap )
			{
				// Don't bother checking, just try to remove it if it exists
				pair.Value.Remove( event_handler );
			}
		}

		/// <summary>
		/// Tell anyone who gives a shit that this happened
		/// </summary>
		public static void broadcastEvent( IGameEvent game_event )
		{
			Type type = game_event.GetType();
			if ( handlerMap.ContainsKey( type ) )
			{
				// Foreach handler associated with this event type, handle this event
				handlerMap[ type ].ForEach( 
						delegate( IEventHandler event_handler ) 
						{ event_handler.handleEvent( game_event ); } 
						);
			}
		}
	}
}
