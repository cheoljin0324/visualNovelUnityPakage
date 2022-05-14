using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    FadeDialBox fadial;
    ObjectSet ObSet;
    InstantiateDialBox instDial;
    DelDialBox delDial;

    private void Awake()
    {
        fadial = GetComponent<FadeDialBox>();
        ObSet = GetComponent<ObjectSet>();
        instDial = GetComponent<InstantiateDialBox>();
        delDial = GetComponent<DelDialBox>();
    }

    public void DialSet()
    {
        instDial.DialogueBoxSet(ObSet.DialBox);
    }

    public void DialOff()
    {
        delDial.DelObject();
    }

    public void Fade(bool isFade)
    {
        if (isFade == true)
        {
            fadial.InstDialFade(ObSet.DialBox);
        }
        else
        {
            fadial.DelDialFade(ObSet.DialBox);
        }
    }
}
