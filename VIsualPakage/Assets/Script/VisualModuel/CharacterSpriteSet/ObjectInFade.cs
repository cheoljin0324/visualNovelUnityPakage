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
            if(charOb.BObjectList.Count == 0||charOb.ObjectList[i].GetComponent<SpriteRenderer>().sprite != charOb.BObjectList[i].GetComponent<SpriteRenderer>().sprite)
            {
                charOb.ObjectList[i].GetComponent<SpriteRenderer>().DOFade(1f, 0.5f);
            }

        }

    }
}
