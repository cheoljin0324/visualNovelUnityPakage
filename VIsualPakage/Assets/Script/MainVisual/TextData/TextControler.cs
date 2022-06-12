using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControler : MonoBehaviour
{

    //�ؽ�Ʈ ���� ĳ���� ���� ���� ����
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
        //ĳ��
        textname = GetComponent<TextNameSet>();
        textdial = GetComponent<TextDialogueSet>();
        textSize = GetComponent<TextSizeSet>();
        textPos = GetComponent<TextPositionSet>();
        dialData = GetComponent<DialDataSet>();
        nameData = GetComponent<NameDataSet>();
        delTex = GetComponent<DelText>();
    }

    /// <summary>
    /// ������ ����
    /// </summary>
    public void InstName()
    {
        textname.InstName();
        textSize.NameSizeSet(textname.NameTextN);
        textPos.NamePosSet(textname.NameTextN);
        textname.NameTextN.GetComponent<Text>().text = "";
    }

    public void ReStart()
    {
        textname.TextEmpty();
        textdial.TextEmpty();
    }

    /// <summary>
    /// ������ ����
    /// </summary>
    public void DeleteName()
    {
        delTex.DelOb(textname.NameTextN);
    }

    /// <summary>
    /// ���̾�α׸� ����
    /// </summary>
    public void DeleteDial()
    {
        delTex.DelOb(textdial.DialTextN);
    }

    /// <summary>
    /// ������ ������Ʈ
    /// </summary>
    /// <param name="Name"></param>
    public void UpdateName(string Name)
    {
        nameData.NameData(Name);
    }

    /// <summary>
    /// ���̾�α׸� ����
    /// </summary>
    public void InstDial()
    {
        textdial.InstName();
        textSize.DialSizeSet(textdial.DialTextN);
        textPos.DialPosSet(textdial.DialTextN);
        textdial.DialTextN.GetComponent<Text>().text = "";
    }

    /// <summary>
    /// ���̾�α׸� ����
    /// </summary>
    /// <param name="Dial"></param>
    public void UpdateDial(string Dial)
    {
        dialData.DialData(Dial);
    }
}
