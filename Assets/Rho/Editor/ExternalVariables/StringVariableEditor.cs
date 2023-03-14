using UnityEditor;

namespace rho
{
	[CustomEditor(typeof(rho.StringVariable))]
	public class StringVariableEditor : BaseExternalVariableEditor<string>
	{
		protected override string GetFieldValue()
		{
			return EditorGUILayout.DelayedTextField("Value", _variable.Value);
		}
	}
}
