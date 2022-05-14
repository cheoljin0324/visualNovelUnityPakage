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

    public void ObOut()
    {
        for (int i = 0; i < charOb.ObjectList.Count; i++)
        {
                charOb.ObjectList[i].GetComponent<SpriteRenderer>().DOFade(0f, charOb.fadeTime);
            
        }

    }
}
