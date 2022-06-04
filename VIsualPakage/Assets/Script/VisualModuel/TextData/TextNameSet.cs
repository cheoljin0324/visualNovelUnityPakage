using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNameSet : MonoBehaviour
{
    TextObject texting;
    [HideInInspector]
    public GameObject NameTextN;

    private void Awake()
    {
        texting = GetComponent<TextObject>();
    }

    public void InstName()
    {
        NameTextN = Instantiate(texting.NameText);
        NameTextN.transform.parent = GameObject.Find("Canvas").transform;
    }

    public void NameSet(string Name)
    {
        NameTextN.GetComponent<Text>().text = Name;
    }



}
