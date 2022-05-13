using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDialBox : MonoBehaviour
{
    [HideInInspector]
    public GameObject DialBox;

    FadeDialBox fade;

    public void Awake()
    {
        fade = GetComponent<FadeDialBox>();
    }

    public void DialogueBoxSet(GameObject dialogueBox)
    {
        DialBox = Instantiate(dialogueBox);
        DialBox.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        fade.InstDialFade(DialBox);
    }

}
