using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("DialoguePackage/TextSetting")]
[RequireComponent(typeof(TextNameSet))]
[RequireComponent(typeof(TextDialogueSet))]
[RequireComponent(typeof(TextControler))]
[RequireComponent(typeof(TextSizeSet))]
[RequireComponent(typeof(TextPositionSet))]
[RequireComponent(typeof(NameDataSet))]
[RequireComponent(typeof(DialDataSet))]
[RequireComponent(typeof(DelText))]


public class TextObject : MonoBehaviour
{
    [Header("�̸� ������Ʈ ������")]
    public GameObject NameText;
    [Header("���̾� ������")]
    public GameObject DialText;
}
