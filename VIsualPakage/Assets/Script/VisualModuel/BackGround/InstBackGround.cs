using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBackGround : MonoBehaviour
{
    BackSpriteOb backOb;

    GameObject backGround;

    void Awake()
    {
        backOb = GetComponent<BackSpriteOb>();
    }

    public void InstantBak()
    {
        backGround = Instantiate(backOb.backGameOB);
    }
}
