using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace rho
{
	[CustomEditor(typeof(rho.BooleanVariable))]
	public class BoolVariableEditor : BaseExternalVariableEditor<bool>
	{
		protected override bool GetFieldValue()
		{
			return EditorGUILayout.Toggle("Value", _variable.Value);
		}
	}
}
