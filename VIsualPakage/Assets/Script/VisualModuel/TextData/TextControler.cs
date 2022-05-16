using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControler : MonoBehaviour
{
    TextNameSet textname;
    TextDialogueSet textdial;
    TextSizeSet textSize;
    TextPositionSet textPos;
    DialDataSet dialData;
    NameDataSet nameData;
    DelText delTex;

    public bool isTyping = false;


    private void Awake()
    {
        textname = GetComponent<TextNameSet>();
        textdial = GetComponent<TextDialogueSet>();
        textSize = GetComponent<TextSizeSet>();
        textPos = GetComponent<TextPositionSet>();
        dialData = GetComponent<DialDataSet>();
        nameData = GetComponent<NameDataSet>();
        delTex = GetComponent<DelText>();
    }

    public void InstName()
    {
        textname.InstName();
        textSize.NameSizeSet(textname.NameTextN);
        textPos.NamePosSet(textname.NameTextN);
        textname.NameTextN.GetComponent<Text>().text = "";
    }

    public void DeleteName()
    {
        delTex.DelOb(textname.NameTextN);
    }

    public void DeleteDial()
    {
        delTex.DelOb(textdial.DialTextN);
    }

    public void UpdateName(string Name)
    {
        nameData.NameData(Name);
    }

    public void InstDial()
    {
        textdial.InstName();
        textSize.DialSizeSet(textdial.DialTextN);
        textPos.DialPosSet(textdial.DialTextN);
        textdial.DialTextN.GetComponent<Text>().text = "";
    }

    public void UpdateDial(string Dial)
    {
        dialData.DialData(Dial);
    }
}
