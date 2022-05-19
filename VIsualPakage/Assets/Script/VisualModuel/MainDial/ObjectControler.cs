using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    //다이얼 박스 fade를 위한 캐싱 이전 변수
    FadeDialBox fadial;
    //Object를 가져와줄 ObjectSet 클래스의 변수
    ObjectSet ObSet;
    //다이얼 박스를 만들어줄 InstantiateDialBox 변수
    InstantiateDialBox instDial;
    //다이얼 박스를 지워줄 delDial 
    DelDialBox delDial;

    private void Awake()
    {
        //캐싱
        fadial = GetComponent<FadeDialBox>();
        ObSet = GetComponent<ObjectSet>();
        instDial = GetComponent<InstantiateDialBox>();
        delDial = GetComponent<DelDialBox>();
    }

    /// <summary>
    /// 다이얼 박스 셋
    /// </summary>
    public void DialSet()
    {
        instDial.DialogueBoxSet(ObSet.DialBox);
    }

    /// <summary>
    /// 다이얼을 꺼준다.
    /// </summary>
    public void DialOff()
    {
        delDial.DelObject();
    }

    /// <summary>
    /// 페이드
    /// </summary>
    /// <param name="isFade"></param>
    public void Fade(bool isFade)
    {
        if (isFade == true)
        {
            fadial.InstDialFade(ObSet.DialBox);
        }
        else
        {
            fadial.DelDialFade(ObSet.DialBox);
        }
    }
}
