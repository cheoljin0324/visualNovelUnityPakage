using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialSpriteSet : MonoBehaviour
{
    public void SpriteSet(List<GameObject> newOb,Sprite[] SetSprite)
    {
        for(int i = 0; i<newOb.Count; i++)
        {
            newOb[i].GetComponent<SpriteRenderer>().sprite = SetSprite[i];
        }
    }
}
