using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControler : MonoBehaviour
{
    DelDialBox delDial;
    InstantiateDialBox instDialBox;
    FadeDialBox FadeControl;

    public GameObject DialBox;

    private void Awake()
    {
        delDial = GetComponent<DelDialBox>();
        instDialBox = GetComponent<InstantiateDialBox>();
        FadeControl = GetComponent<FadeDialBox>();
    }

    public void deleteDial()
    {
        delDial.DelObject();
    }

    public void NewDial(GameObject Dial)
    {
        instDialBox.DialogueBoxSet(Dial);
        DialBox = instDialBox.DialBox;
        FadeControl.InstDialFade(instDialBox.DialBox);
    }

    public void FadeOutDial(GameObject Dial)
    {
        FadeControl.DelDialFade(Dial);
    }

}
