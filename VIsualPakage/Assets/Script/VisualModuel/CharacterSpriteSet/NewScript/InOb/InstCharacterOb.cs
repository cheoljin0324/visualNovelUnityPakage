using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstCharacterOb : MonoBehaviour
{
    charData Getchar;

    private void Awake()
    {
        Getchar = GetComponent<charData>();
    }

    public void InstantiateObject(int Length, List<List<GameObject>> Char)
    {
        List<GameObject> Emotion = new List<GameObject>();
        for(int i = 0; i<Length; i++)
        {
            GameObject NChar= Instantiate(Getchar.Inst);
            Emotion.Add(NChar);
        }
        Char.Add(Emotion);
    }

    public void SetPos()
    {

    }
}
