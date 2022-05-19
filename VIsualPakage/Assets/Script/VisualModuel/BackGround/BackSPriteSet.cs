using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSPriteSet : MonoBehaviour
{
    /// <summary>
    /// 오브젝트들을 가지고 Back이라는 게임오브젝트 리스트 와 스프라이트 배열을 갖고와준다.
    /// </summary>
    /// <param name="Back"></param>
    /// <param name="spriteSet"></param>
    public void BackSpriteSet(List<GameObject> Back, Sprite[] spriteSet)
    {
        //가지고 있는 오브젝트 만큼 반복을 돈다.
        for(int i = 0; i<Back.Count; i++)
        {
            //Back에 있는 오브젝트 내부에 스프라이트렌더러 라는 컴포넌트를 캐싱 해당 컴포넌트에 스프라이트를 spriteSet에 i로 변경
            Back[i].GetComponent<SpriteRenderer>().sprite = spriteSet[i];
            //오브젝트 우선 순위를 낮춘다 1(선택지) -> 0(다이얼로그 및 텍스트) -> -1(캐릭터 or 이벤트 CG) -> -2(배경)
            Back[i].GetComponent<SpriteRenderer>().sortingOrder = -2;
            //모든 컬러값을 0으로 초기화
            Back[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

}
