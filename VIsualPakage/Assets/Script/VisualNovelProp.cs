using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(DialogueCLS))]
public class VisualNovelProp : Editor
{

    DialogueCLS dialCls;

    void OnEnable()
    {
        dialCls = (DialogueCLS)target;
    }


    public override void OnInspectorGUI()
    {

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("dialogueStructs"));
        serializedObject.ApplyModifiedProperties();

    }
}



