using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControler : MonoBehaviour
{
    DelDialBox delDial;
    InstantiateDialBox instDialBox;
    FadeDialBox FadeControl;

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
        FadeControl.InstDialFade(instDialBox.DialBox);
    }

    public void FadeOutDial(GameObject Dial)
    {
        FadeControl.DelDialFade(Dial);
    }

}
