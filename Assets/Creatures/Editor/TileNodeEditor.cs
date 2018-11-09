using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileNode))]
public class TileNodeEditor : Editor
{
    public SerializedProperty tileTypeMask;

    void OnEnable()
    {
        tileTypeMask = serializedObject.FindProperty("tileTypeMask");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        tileTypeMask.intValue = (int)((TileNode.TileType)EditorGUILayout.EnumMaskField("Tile Type Mask", (TileNode.TileType)tileTypeMask.intValue));

        serializedObject.ApplyModifiedProperties();
    }
}