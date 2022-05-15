using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControler : MonoBehaviour
{
    TextNameSet textname;
    TextDialogueSet textdial;


    private void Awake()
    {
        textname = GetComponent<TextNameSet>();
        textdial = GetComponent<TextDialogueSet>();
    }

    private void Start()
    {
        textname.InstName();
        textdial.InstName();
    }
}
