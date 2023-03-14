using UnityEditor;
using UnityEngine;

namespace rho
{
    [CustomEditor(typeof(Event))]
    public class EventButton : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Event myScript = (Event) target;
            if(GUILayout.Button("Raise"))
            {
                myScript.Raise();
            }
        }
    }
}