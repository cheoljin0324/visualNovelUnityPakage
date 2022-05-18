using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeDialBox : MonoBehaviour
{
    /// <summary>
    /// ���� �ɶ� ���̾� �α� ���̵�
    /// </summary>
    /// <param name="DialBox"></param>
    public void DelDialFade(GameObject DialBox)
    {
        DialBox.GetComponent<SpriteRenderer>().DOFade(0f, 0.5f);
    }

    /// <summary>
    /// ���� �ɶ� ���̾� �α� ���̵�
    /// </summary>
    /// <param name="DialBox"></param>
    public void InstDialFade(GameObject DialBox)
    {
        DialBox.GetComponent<SpriteRenderer>().DOFade(1f, 0.5f);
    }
}
