using UnityEditor;

namespace rho
{
    // Simple Editor Replacement
    // Does two simple things:
    // * Reorders the Values based off priority
    // * Hides Starting State value if override toggle is off
    [CustomEditor(typeof(ExternStateBehaviorStateMachine))]
    public class ExternStateBehaviorStateMachineEditor : Editor
    {
        SerializedProperty _states;
        SerializedProperty _stateChangedEvent;
        SerializedProperty _startingState;
        SerializedProperty _overrideInitialValue;
        SerializedProperty _externState;

        protected virtual void OnEnable()
        {
            _states = serializedObject.FindProperty("_states");
            _stateChangedEvent = serializedObject.FindProperty("_stateChangedEvent");
            _startingState = serializedObject.FindProperty("_startingState");
            _overrideInitialValue = serializedObject.FindProperty("_overrideInitialValue");
            _externState = serializedObject.FindProperty("_externState");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(_externState);
            EditorGUILayout.PropertyField(_states);
            EditorGUILayout.PropertyField(_stateChangedEvent);
            EditorGUILayout.PropertyField(_overrideInitialValue);

            // Only render starting value if the toggle is set
            if (_overrideInitialValue.boolValue)
            {
                EditorGUILayout.PropertyField(_startingState);
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}