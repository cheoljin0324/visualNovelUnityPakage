using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectInFade : MonoBehaviour
{
    CharacterObjectSet charOb;
    private void Awake()
    {
        charOb = GetComponent<CharacterObjectSet>();
    }

    public void ObIn(int setNum)
    {    
       charOb.ObjectList[setNum].GetComponent<SpriteRenderer>().DOFade(1f, charOb.fadeTime);
    }
}
