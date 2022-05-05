using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spritFade;

    public void inFade()
    {
        StartCoroutine("FadeCoroutine");
    }

    IEnumerator FadeCoroutine()
    {
        spritFade.DOFade(1f, 0.8f);
        yield return new WaitForSeconds(2f);
        spritFade.DOFade(0f, 0.6f);
    }
}
