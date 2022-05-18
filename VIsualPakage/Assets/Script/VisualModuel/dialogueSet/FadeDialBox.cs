using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeDialBox : MonoBehaviour
{
    /// <summary>
    /// 삭제 될때 다이얼 로그 페이드
    /// </summary>
    /// <param name="DialBox"></param>
    public void DelDialFade(GameObject DialBox)
    {
        DialBox.GetComponent<SpriteRenderer>().DOFade(0f, 0.5f);
    }

    /// <summary>
    /// 생성 될때 다이얼 로그 페이드
    /// </summary>
    /// <param name="DialBox"></param>
    public void InstDialFade(GameObject DialBox)
    {
        DialBox.GetComponent<SpriteRenderer>().DOFade(1f, 0.5f);
    }
}
