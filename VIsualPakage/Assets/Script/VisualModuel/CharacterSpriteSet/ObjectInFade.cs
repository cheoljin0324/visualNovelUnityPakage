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

    public void ObIn()
    {
        for(int i = 0; i<charOb.ObjectList.Count; i++)
        {
            charOb.ObjectList[i].GetComponent<SpriteRenderer>().DOFade(1f, 0.5f);
        }

    }
}
