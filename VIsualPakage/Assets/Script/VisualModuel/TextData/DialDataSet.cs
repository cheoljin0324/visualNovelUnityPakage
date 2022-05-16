using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialDataSet : MonoBehaviour
{
    TextDialogueSet textDial;
    TextControler textCon;
    public float TypingSpd = 0.05f;

    private void Awake()
    {
        textDial = GetComponent<TextDialogueSet>();
        textCon = GetComponent<TextControler>();

    }

    public void DialData(string Dial)
    {
        StartCoroutine("Typing", Dial);
    }

    IEnumerator Typing(string Dial)
    {
        int index = 0;

        textCon.isTyping = true;

        while(index < Dial.Length+1)
        {
            textDial.DialTextN.GetComponent<Text>().text = Dial.Substring(0, index);
            index++;
            if (textCon.isTyping == false)
            {
                textDial.DialTextN.GetComponent<Text>().text = Dial;
                index = Dial.Length;
            }
            yield return new WaitForSeconds(TypingSpd);
        }

        textCon.isTyping = false;
    }
}
