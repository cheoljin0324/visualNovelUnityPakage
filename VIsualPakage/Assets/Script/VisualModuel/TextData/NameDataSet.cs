using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDataSet : MonoBehaviour
{
    //텍스트 네임셋을 캐싱하기 위한 변수 선언
    TextNameSet nameSet;

    private void Awake()
    {
        //네임 셋 캐싱
        nameSet = GetComponent<TextNameSet>();
    }

    /// <summary>
    /// 네임을 초기화 해주는 함수
    /// </summary>
    /// <param name="Name"></param>
    public void NameData(string Name)
    {
        //네임셋에 텍스트 컴포넌트를 캐싱 및 해당 텍스트의 이름을  초기화
        nameSet.NameTextN.GetComponent<Text>().text = Name;
    }
}
