using UnityEditor;

namespace rho
{
	[CustomEditor(typeof(rho.IntVariable))]
	public class IntVariableEditor : BaseExternalVariableEditor<int>
	{
		protected override int GetFieldValue()
		{
			return EditorGUILayout.DelayedIntField("Value", _variable.Value);
		}
	}
}
