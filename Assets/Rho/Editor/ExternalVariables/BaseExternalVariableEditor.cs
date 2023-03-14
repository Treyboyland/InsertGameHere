using UnityEditor;

namespace rho
{
	public abstract class BaseExternalVariableEditor<T> : Editor
	{
		protected ExternalVariable<T> _variable;

		protected virtual void OnEnable()
		{
			_variable = target as ExternalVariable<T>;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			EditorGUI.BeginChangeCheck();
			var newValue = GetFieldValue();
			if (EditorGUI.EndChangeCheck())
			{
				_variable.Value = newValue;
				EditorUtility.SetDirty(_variable);
			}
		}

		protected abstract T GetFieldValue();
	}
}
