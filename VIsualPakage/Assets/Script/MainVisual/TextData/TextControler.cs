using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControler : MonoBehaviour
{

    //텍스트 관련 캐싱을 위한 변수 선언
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
        //캐싱
        textname = GetComponent<TextNameSet>();
        textdial = GetComponent<TextDialogueSet>();
        textSize = GetComponent<TextSizeSet>();
        textPos = GetComponent<TextPositionSet>();
        dialData = GetComponent<DialDataSet>();
        nameData = GetComponent<NameDataSet>();
        delTex = GetComponent<DelText>();
    }

    /// <summary>
    /// 네임을 생성
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
    /// 네임을 삭제
    /// </summary>
    public void DeleteName()
    {
        delTex.DelOb(textname.NameTextN);
    }

    /// <summary>
    /// 다이얼로그를 삭제
    /// </summary>
    public void DeleteDial()
    {
        delTex.DelOb(textdial.DialTextN);
    }

    /// <summary>
    /// 네임을 업데이트
    /// </summary>
    /// <param name="Name"></param>
    public void UpdateName(string Name)
    {
        nameData.NameData(Name);
    }

    /// <summary>
    /// 다이얼로그를 생성
    /// </summary>
    public void InstDial()
    {
        textdial.InstName();
        textSize.DialSizeSet(textdial.DialTextN);
        textPos.DialPosSet(textdial.DialTextN);
        textdial.DialTextN.GetComponent<Text>().text = "";
    }

    /// <summary>
    /// 다이얼로그를 삭제
    /// </summary>
    /// <param name="Dial"></param>
    public void UpdateDial(string Dial)
    {
        dialData.DialData(Dial);
    }
}
