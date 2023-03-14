using System;
using UnityEngine;

namespace rho
{
	public class ExternVarBehaviorStateMachine<T> : BaseBehaviorStateMachine<T>
		where T : IEquatable<T>
	{
		[SerializeField] protected ExternalVariable<T> _externState;

		protected void OnExternVarChanged(ExternalVariable<T> sender, T oldValue, T newValue) => ChangeState(oldValue, newValue);

		// Override base state to instead refer to the External Variable's value
		protected override T _currentState
		{
			get => _externState.Value;
			set => _externState.Value = value;
		}

		// Serialized flag  for overriding Starting State, in case we want to use the extern variables value instead
		[Tooltip("Should the state machine override the existing value in the external variable with the Starting State value")]
		[SerializeField] protected bool _overrideInitialValue = true;

		protected override void Awake()
		{
			DisableAllStates();
			if (_overrideInitialValue)
			{
				_currentState = _startingState;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_externState.Changed += OnExternVarChanged;
		}

		protected override void OnDisable()
		{
			_externState.Changed -= OnExternVarChanged;
			base.OnDisable();
		}
	}
}
