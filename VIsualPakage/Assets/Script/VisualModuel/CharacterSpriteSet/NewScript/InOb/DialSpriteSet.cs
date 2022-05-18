using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialSpriteSet : MonoBehaviour
{
    /// <summary>
    /// 스프라이트 초기화 리스트 게임오브젝트 or 스프라이트 배열
    /// </summary>
    /// <param name="newOb"></param>
    /// <param name="SetSprite"></param>
    public void SpriteSet(List<GameObject> newOb,Sprite[] SetSprite)
    {
        //newOb라는 오브젝트 카운트
        for(int i = 0; i<newOb.Count; i++)
        {
            //newOb에 해당 스프라이트를 캐싱 후 해당 오브젝트의 스프라이트를 SetSprite에 해당 번호로 초기화
            newOb[i].GetComponent<SpriteRenderer>().sprite = SetSprite[i];
            //오부잭트 컬러를 초기화
            newOb[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            //오브젝트의 우선순위를 -1로 만든다.
            newOb[i].GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }
}
