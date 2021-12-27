using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Game15.Model
{
    [CustomEditor(typeof(LevelData))]
    public class LevelDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            //IMAGE FIELD
            var textureField = serializedObject.FindProperty("LevelImage");
            EditorGUILayout.PropertyField(textureField);

            var img = textureField.objectReferenceValue != null ? textureField.objectReferenceValue as Texture2D : null;            

            //LABEL WITH IMAGE SIZE INFO
            if (img != null)
            {
                EditorGUILayout.HelpBox($"Image size: {img.width} x {img.height}", MessageType.Info);

                if (img.width != img.height)
                {
                    EditorGUILayout.HelpBox("Image is not squared. You should use square image.", MessageType.Error);
                }
            }

            //CELL COUNT IN RAW FIELD
            var cellCountInRow = serializedObject.FindProperty("CellCountInRow");
            EditorGUILayout.PropertyField(cellCountInRow);

            //CELL SPACING FIELD
            var cellSpacing = serializedObject.FindProperty("CellSpacing");
            EditorGUILayout.PropertyField(cellSpacing);

            try
            {
                if (img != null)
                {
                    var cell_size = (serializedObject.targetObject as LevelData).CellSize;
                    EditorGUILayout.HelpBox($"Cell size: {cell_size}", MessageType.Info);
                }
            }
            catch (System.Exception)
            {

            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
