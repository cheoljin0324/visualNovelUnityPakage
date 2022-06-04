using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeSet : MonoBehaviour
{
    TextNameSet nameset;
    TextDialogueSet dialset;

    [Header("�̸��� ��Ʈ ������")]
    public int namefontSize;
    [Header("��ȭ�� ��Ʈ ������")]
    public int dialfontSize;

    [Header("�̸� ����")]
    public Vector2 NameImSize;

    [Header("���̾� ����")]
    public Vector2 DialImSize;




    public void Awake()
    {
        nameset = GetComponent<TextNameSet>();
        dialset = GetComponent<TextDialogueSet>();
    }



    public void DialSizeSet(GameObject dial)
    {
        dialset.DialTextN.GetComponent<Text>().fontSize = namefontSize;
        dialset.DialTextN.GetComponent<Text>().rectTransform.sizeDelta = DialImSize;
    }

    public void NameSizeSet(GameObject name)
    {
        nameset.NameTextN.GetComponent<Text>().fontSize = dialfontSize;
        nameset.NameTextN.GetComponent<Text>().rectTransform.sizeDelta = NameImSize;
    }


}
