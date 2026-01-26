using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TextMeshGlyphAnimator))]

public class TextMeshGlyphAnimatorEditor: Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector first
        DrawDefaultInspector();

        TextMeshGlyphAnimator script = (TextMeshGlyphAnimator)target;

        if (!script.IsDriversValid && script.IsTextValid)
        {
            if (GUILayout.Button("Fix Missing Drivers"))
            {
                Undo.RecordObject(script, "Validate Drivers");
                script.ValidateDrivers();
                EditorUtility.SetDirty(script);                
            }
        }
    }
}
