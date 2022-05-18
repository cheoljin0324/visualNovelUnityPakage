using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSPriteSet : MonoBehaviour
{
    public void BackSpriteSet(GameObject backSpriteRend, Sprite spriteSet)
    {
        backSpriteRend.GetComponent<SpriteRenderer>().sprite = spriteSet;
    }

}
