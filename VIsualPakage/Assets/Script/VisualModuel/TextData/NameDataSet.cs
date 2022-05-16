using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDataSet : MonoBehaviour
{
    TextNameSet nameSet;

    private void Awake()
    {
        nameSet = GetComponent<TextNameSet>();
    }

    public void NameData(string Name)
    {
        nameSet.NameTextN.GetComponent<Text>().text = Name;
    }
}
