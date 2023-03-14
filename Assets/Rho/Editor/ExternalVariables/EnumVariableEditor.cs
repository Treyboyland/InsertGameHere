using System;
using UnityEditor;
using System.Reflection;
using System.Linq;

namespace rho
{
	/**
	 * This base class implements the rendering logic for enum variable editors.
	 * In order to use this, you have to make a new enum, new external enum variable type, and a new Editor for this external variable.
	 * The new editor must have the [CustomEditor(typeof(MyEnumExternalVar))] attribute.
	 */
	public class EnumVariableEditor<T> : BaseExternalVariableEditor<T> where T : System.Enum
	{
		protected bool _isFlag;

		protected override void OnEnable()
		{
			base.OnEnable();

			_isFlag = typeof(T).GetCustomAttributes<FlagsAttribute>().Any();
		}

		protected override T GetFieldValue()
		{
			return (T) (_isFlag ?
				EditorGUILayout.EnumFlagsField("Value", _variable.Value) :
				EditorGUILayout.EnumPopup("Value", _variable.Value)
			);
		}
	}
}
