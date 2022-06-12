using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectDataFlow : MonoBehaviour
{
    TextDataSet textData;
    bool selectIn = false;
    bool instButton = true;
    public int result = 0;
    [Header("페이드를 위한 오브젝트(검은색 스프라이트 하나 깔아주면 됩니다)")]
    public GameObject FadeOb;


    private void Awake()
    {
        //텍스트 데이터를 캐싱
        textData = GetComponent<TextDataSet>();
    }
    public bool SetNext()
    {
        //만약 instButton이 트루면
        if (instButton == true)
        {
            StartCoroutine(Fade());
            //textData에 리스트 갯수만큼
            for (int i = 0; i < textData.dataSet.selectionList.Count; i++)
            {
                //데이터 만큼 버튼 생성
                textData.obEle.Element();
            }
            //데이터 초기화
            textData.DataSet();
            //위치 초기화
            textData.obEle.ButtonPosSet();
            //데이터 넣기
            textData.obEle.SetOnclick();
            //instButton을 끈다.
            instButton = false;
        }
        if (textData.obEle.Set == true)
        {
            StartCoroutine(FadeOut());
            selectIn = true;
            result = textData.obEle.resultNum;
        }

        return selectIn;
    }

    IEnumerator Fade()
    {
        FadeOb.GetComponent<SpriteRenderer>().DOFade(0.5f, 1);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator FadeOut()
    {
        FadeOb.GetComponent<SpriteRenderer>().DOFade(0f, 0.5f);
        yield return new WaitForSeconds(1f);
    }
}
