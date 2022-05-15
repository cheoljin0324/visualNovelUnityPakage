using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectOutFade : MonoBehaviour
{
    CharacterObjectSet charOb;
    private void Awake()
    {
        charOb = GetComponent<CharacterObjectSet>();
    }

    public void ObOut(int set)
    {
       charOb.ObjectList[set].GetComponent<SpriteRenderer>().DOFade(0f, charOb.fadeTime);
    }
}
