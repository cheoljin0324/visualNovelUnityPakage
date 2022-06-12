using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBackGround : MonoBehaviour
{
    //백그라운드 스프라이트 오브젝트를 불러와 생성하기 위한 코드
    BackSpriteOb backOb;

    void Awake()
    {
        //backOB를 BackSpriteOb로 캐싱
        backOb = GetComponent<BackSpriteOb>();
    }

    /// <summary>
    /// 오브젝트를 보관할 리스트 그리고 생성될 백그라운드 마지막으로 현재 배경 스프라이트 갯수를 가져와 비교해줄 변수를 매개변수로 가져 오브젝트를 보관 시키고 있는 스프라이트 만큼 생성해주는 함수 생성
    /// </summary>
    /// <param name="gameBackList"></param>
    /// <param name="backGround"></param>
    /// <param name="backAmount"></param>
    public void InstantBack(List<GameObject> gameBackList,GameObject backGround,int backAmount)
    {
        //가지고 있는 백 스프라이트 만큼 반복
        for(int i = 0; i<backAmount; i++)
        {
            //백그라운드 빈 스프라이트 생성 및 넣어준다
            backGround = Instantiate(backOb.backGameOB);
            //넣어진 backGround 스프라이트는 gameBackList라는 오브젝트 리스트에 넣어준다.
            gameBackList.Add(backGround);
        }

    }
}
