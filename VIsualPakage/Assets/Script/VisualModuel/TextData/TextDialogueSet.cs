using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogueSet : MonoBehaviour
{
    TextObject texting;
    public GameObject DialTextN;

    private void Awake()
    {
        texting = GetComponent<TextObject>();
    }

    public void InstName()
    {
        DialTextN = Instantiate(texting.DialText);
        DialTextN.transform.parent = GameObject.Find("Canvas").transform;
    }

    public void NameSet(string Name)
    {
        DialTextN.GetComponent<Text>().text = Name;
    }
}
