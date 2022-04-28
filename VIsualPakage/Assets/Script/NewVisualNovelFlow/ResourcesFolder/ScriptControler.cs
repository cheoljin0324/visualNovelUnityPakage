using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSFEngine;

public class ScriptControler : MonoBehaviour
{
    public Action<string, int, int> SetCg;
    public Action<string, int, int, string, int, int> SetCgS;
    public Action<string, int, int, string, int, int, string, int, int> SetCgT;
    public static Func<int, int> SetPos;


    private void Start()
    {
        SetCg += SetStandCG.SetSprite;
        SetCgS += SetStandCG.SetSprite;
        SetCgT += SetStandCG.SetSprite;
        SetPos += SetPosition.setPosition;
    }
}
