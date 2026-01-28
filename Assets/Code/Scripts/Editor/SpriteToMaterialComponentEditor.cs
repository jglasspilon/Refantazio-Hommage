using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpriteToMaterialComponent))]
public class SpriteToMaterialComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SpriteToMaterialComponent comp = (SpriteToMaterialComponent)target;

        EditorGUILayout.Space();

        if (GUILayout.Button("Apply Sprite"))
        {
            comp.ApplySprite();
        }
    }
}