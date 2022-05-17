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
            newOb[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            newOb[i].GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }
}
