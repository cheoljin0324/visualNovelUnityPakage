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
        var list = dialCls.dialogueStructs;
        int newCount = Mathf.Max(0, EditorGUILayout.IntField("size", list.Count));
        while (newCount < list.Count)
            list.RemoveAt(list.Count - 1);
        while (newCount > list.Count)
            list.Add(null);

        for (int i = 0; i < list.Count; i++)
        {
            list[i] = (Bar)EditorGUILayout.ObjectField(list[i], typeof(Bar));
        }

    }



