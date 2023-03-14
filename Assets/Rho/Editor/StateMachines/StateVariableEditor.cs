using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace rho
{
    [CustomEditor(typeof(StateVariable))]
    public class StateVariableEditor : BaseExternalVariableEditor<StateValue>
    {
        protected override StateValue GetFieldValue()
        {
            return (StateValue) EditorGUILayout.ObjectField("Value", _variable.Value, typeof(StateValue), false);
        }
    }
}