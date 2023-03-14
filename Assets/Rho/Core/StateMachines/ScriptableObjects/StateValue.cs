using System;
using UnityEngine;

namespace rho
{
    [CreateAssetMenu(menuName = "Rho/State Machine - State")]
    public class StateValue : ScriptableObject, IEquatable<StateValue>
    {
        public bool Equals(StateValue other) => ReferenceEquals(this, other);
    }
}