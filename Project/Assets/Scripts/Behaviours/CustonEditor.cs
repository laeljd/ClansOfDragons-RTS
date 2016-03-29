using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CustonEditor))]
public class CustonEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("This is a help box", MessageType.Info);
    }
}