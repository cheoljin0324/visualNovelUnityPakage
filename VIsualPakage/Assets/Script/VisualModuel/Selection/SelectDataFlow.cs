using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDataFlow : MonoBehaviour
{
    TextDataSet textData;
    bool selectIn = false;
    bool instButton = true;
    public int result = 0;


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
            selectIn = true;
            result = textData.obEle.resultNum;
        }

        return selectIn;
    }
}
