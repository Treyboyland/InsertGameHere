using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace rho
{
	[CustomEditor(typeof(rho.FloatVariable))]
	public class FloatVariableEditor : BaseExternalVariableEditor<float>
	{
		protected override float GetFieldValue()
		{
			return EditorGUILayout.DelayedFloatField("Value", _variable.Value);
		}
	}
}
