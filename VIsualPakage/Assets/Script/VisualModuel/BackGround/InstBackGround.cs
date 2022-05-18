using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBackGround : MonoBehaviour
{
    BackSpriteOb backOb;

    void Awake()
    {
        backOb = GetComponent<BackSpriteOb>();
    }

    public void InstantBack(GameObject backGround)
    {
        backGround = Instantiate(backOb.backGameOB);
    }
}
