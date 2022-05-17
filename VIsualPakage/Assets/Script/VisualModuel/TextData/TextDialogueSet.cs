using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogueSet : MonoBehaviour
{
    //텍스트 오브젝트 변수 선언
    TextObject texting;

    //해당 변수를 넣어주기 위한 변수 선언
    public GameObject DialTextN;

    private void Awake()
    {
        //캐싱
        texting = GetComponent<TextObject>();

    }

    /// <summary>
    /// 네임 생성
    /// </summary>
    public void InstName()
    {
        //다이얼 텍스트에 texting이라는 이름의 텍스트를 생성
        DialTextN = Instantiate(texting.DialText);
        //캔버스에 상속
        DialTextN.transform.parent = GameObject.Find("Canvas").transform;
    }

    public void NameSet(string Name)
    {
        //캐싱
        DialTextN.GetComponent<Text>().text = Name;
    }


}
