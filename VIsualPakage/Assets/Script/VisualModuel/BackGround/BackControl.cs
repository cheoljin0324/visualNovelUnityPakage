using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackControl : MonoBehaviour
{
    InstBackGround insBack;
    BackSPriteSet backSp;
    BackSpriteOb backSpriteOB;

    public void Awake()
    {
        insBack = GetComponent<InstBackGround>();
        backSp = GetComponent<BackSPriteSet>();
        backSpriteOB = GetComponent<BackSpriteOb>();
    }

    public void BackInstantiate()
    {
        insBack.InstantBack(backSpriteOB.backGameOB);
    }

    public void backSpriteSet(Sprite spriteSet)
    {
        backSp.BackSpriteSet(backSpriteOB.backGameOB, spriteSet);
    }
   
}
