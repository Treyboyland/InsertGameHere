using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace rho
{
	/**
	 * This is a State Machine that turns off and on Unity behaviors to simulate states.
	 *
	 * How to Use:
	 * 1. Create a new Scipt which inherits this base class, and provided it the type used to identify a State (probably gunna be a custom enum).
	 * 2. Attach the new State Machine type to a GameObject
	 * 3. Create and attach behaviors to a game object that will act as your state.
	 * 4. In the StateMachine component, create the associations between state idenitfier <T> value and behavior.
	 * 5. Set the starting state
	 * 6. Play!
	 */
	public class BaseBehaviorStateMachine<T> : MonoBehaviour
		where T : IEquatable<T>
	{
		[Serializable]
		protected class StateInfo
		{
			public T Name;
			public List<Behaviour> Behaviors;
			public List<GameObject> GameObjects;

			public void SetEnabled(bool enabled)
			{
				Behaviors.ForEach(b => b.enabled = enabled);
				GameObjects.ForEach(go => go.SetActive(enabled));
			}
		}

		[SerializeField] protected List<StateInfo> _states = new List<StateInfo>();
		[SerializeField] protected T _startingState;

		/// <summary> (Old State Name, New State Name) Event Called After States changed</summary>
		[SerializeField] protected UnityEvent<T, T> _stateChangedEvent;

		protected virtual T _currentState { get; set; }

		public virtual T State
		{
			get => _currentState;
			set
			{
				var oldValue = _currentState;
				_currentState = value;
				ChangeState(oldValue, _currentState);
			}
		}

		protected virtual void ChangeState(T oldValue, T newValue)
		{
			FindState(oldValue)?.SetEnabled(false);
			FindState(newValue)?.SetEnabled(true);
			_stateChangedEvent.Invoke(oldValue, newValue);
		}

		protected virtual void DisableAllStates() => _states.ForEach(stateInfo => stateInfo.SetEnabled(false));

		protected virtual StateInfo FindState(T name) => _states.FirstOrDefault(stateInfo => stateInfo.Name.Equals(name));

#region Monobehavior Methods

		virtual protected void Awake()
		{
			DisableAllStates();
			_currentState = _startingState;
		}

		virtual protected void OnEnable()
		{
			FindState(_currentState)?.SetEnabled(true);
		}

		virtual protected void OnDisable()
		{
			DisableAllStates();
		}

#endregion
	}
}
