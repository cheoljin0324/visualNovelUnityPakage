using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DelText : MonoBehaviour
{

    /// <summary>
    /// 오브젝트 삭제 함수
    /// </summary>
    /// <param name="TextSet"></param>
  public void DelOb(GameObject TextSet)
    {
        //텍스트 부분을 캐싱 한 후 DOFade를 통한 페이드 효과 연출
        TextSet.GetComponent<Text>().DOFade(0f, 0.5f);
        //DesOb라는 코루틴 실행
        StartCoroutine(DesOb(TextSet));
    }

    IEnumerator DesOb(GameObject TextSet)
    {
        //페이드를 작업 하는 0.5초 작업 후
        yield return new WaitForSeconds(0.5f);
        //TextSet이라는 게임 오브젝트를 꺼준다.
        TextSet.gameObject.SetActive(false);
    }
}
