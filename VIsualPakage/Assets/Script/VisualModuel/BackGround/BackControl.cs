using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackControl : MonoBehaviour
{
    //배경 생성 클래스의 변수
    InstBackGround insBack;
    //배경 스프라이트 초기화의 변수
    BackSPriteSet backSp;  
    //배경 오브젝트
    BackSpriteOb backSpriteOB;
    //배경 사진
    BackSpriteDB backSPrite;

    //배경 오브젝트 들을 받을 리스트
    public List<GameObject> BackOBject;

    public void Awake()
    {
        //캐싱
        insBack = GetComponent<InstBackGround>();
        backSp = GetComponent<BackSPriteSet>();
        backSpriteOB = GetComponent<BackSpriteOb>();
        backSPrite = GetComponent<BackSpriteDB>();
    }

    /// <summary>
    /// 비주얼노벨 컨트롤러에서 써줄 배경 생성툴(정확히는 투명도를 올려주는거임) 
    /// </summary>
    /// <param name="useBack"></param>
    public void InSetting(int useBack)
    {
        BackOBject[useBack].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    /// <summary>
    /// 비주얼노벨 컨트롤러에서 써줄 배경 삭제툴(정확히는 투명도를 내려주는거임)
    /// </summary>
    /// <param name="outBack"></param>
    public void OutSetting(int outBack)
    {
        BackOBject[outBack].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    /// <summary>
    /// 배경 제작
    /// </summary>
    public void BackInstantiate()
    {
        insBack.InstantBack(BackOBject,backSpriteOB.backGameOB,backSPrite.backSprite.Length);
    }

    /// <summary>
    /// 초기 배경 초기화
    /// </summary>
    public void backSpriteSet()
    {
        backSp.BackSpriteSet(BackOBject, backSPrite.backSprite);
    }
   
}
