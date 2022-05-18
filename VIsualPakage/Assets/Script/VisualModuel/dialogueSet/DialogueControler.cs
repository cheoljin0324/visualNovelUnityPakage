using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControler : MonoBehaviour
{
    //다이얼 박스 삭제를 위한 클래스
    DelDialBox delDial;
    //다이얼 박스 생성을 위한 클래스
    InstantiateDialBox instDialBox;
    //페이드를 위한 클래스
    FadeDialBox FadeControl;

    //다이얼 박스 오브젝트 생성
    public GameObject DialBox;

    private void Awake()
    {
        //오브젝트 캐싱
        delDial = GetComponent<DelDialBox>();
        instDialBox = GetComponent<InstantiateDialBox>();
        FadeControl = GetComponent<FadeDialBox>();
    }

    /// <summary>
    /// 오브젝트 삭제
    /// </summary>
    public void deleteDial()
    {
        delDial.DelObject();
    }

    /// <summary>
    /// 새로운 다이얼 로그 생성 및 초기화
    /// </summary>
    /// <param name="Dial"></param>
    public void NewDial(GameObject Dial)
    {
        instDialBox.DialogueBoxSet(Dial);
        DialBox = instDialBox.DialBox;
        FadeControl.InstDialFade(instDialBox.DialBox);
    }

    //페이드 아웃오브젝트
    public void FadeOutDial(GameObject Dial)
    {
        FadeControl.DelDialFade(Dial);
    }

}
