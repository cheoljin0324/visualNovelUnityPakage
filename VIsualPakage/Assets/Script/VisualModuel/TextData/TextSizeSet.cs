using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeSet : MonoBehaviour
{
    TextNameSet nameset;
    TextDialogueSet dialset;

    [Header("이름의 폰트 사이즈")]
    public int namefontSize;
    [Header("대화형 폰트 사이즈")]
    public int dialfontSize;

    [Header("이름 범위")]
    public Vector2 NameImSize;

    [Header("다이얼 범위")]
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
