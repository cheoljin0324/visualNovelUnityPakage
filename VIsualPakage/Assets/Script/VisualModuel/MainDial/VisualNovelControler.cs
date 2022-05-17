using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovelControler : MonoBehaviour
{
    VisualSet dataSet;
    ObjectSet objectSet;
    DialogueControler dialControl;
    TextControler textCon;
    CharacetObControler CharCon;

    public bool isFade = false;

    void Awake()
    {
        objectSet = GameObject.Find("ObjectSetOb").GetComponent<ObjectSet>();
        dialControl = GameObject.Find("ObjectSetOb").GetComponent<DialogueControler>();
        textCon = GameObject.Find("TextManager").GetComponent<TextControler>();
        CharCon = GetComponent<CharacetObControler>();
        dataSet = GetComponent<VisualSet>();
    }

    void DelOB()
    {
        CharCon.CharDel();
    }

    public bool UpdateDialogue()
    {
        if (dataSet.isFirst == true)
        {
            CharCon.CreaterCharacetOb();
            for(int i = 0; i<dataSet.dialogue[dataSet.currentDialogueIndex].charintPos.Length; i++)
            {
                CharCon.SetPos(i);
            }
            SetNextDialogue();
            dataSet.isFirst = false;
        }

        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (textCon.isTyping == true)
                {
                    textCon.isTyping = false;
                }
                else
                {
                    if (dataSet.dialogue.Length > dataSet.currentDialogueIndex + 1)
                    {
                        SetNextDialogue();
                    }
                    else
                    {
                        dialControl.FadeOutDial(dialControl.DialBox);

                        DelOB();
                        textCon.DeleteDial();
                        textCon.DeleteName();
                        
                        return true;
                    }

                }


            }
        }
        return false;
    }



    public void SetNextDialogue()
    {
        if (dataSet.isFirst == false)
        {
            dataSet.currentDialogueIndex++;
            textCon.UpdateName(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[dataSet.dialogue[dataSet.currentDialogueIndex].nowMent].charNumber].Name);
            textCon.UpdateDial(dataSet.dialogue[dataSet.currentDialogueIndex].DialogueData);
            if (dataSet.currentDialogueIndex == dataSet.dialogue.Length)
            {
                CharCon.DelFade();
            }
            else
            {
                CharCon.EmotionFade();
                CharCon.TransPos();
            }
           
        }
        else
        {
            CharCon.CreateFade();
            dialControl.NewDial(objectSet.DialBox);
            textCon.InstName();
            textCon.InstDial();
            textCon.UpdateName(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[dataSet.dialogue[dataSet.currentDialogueIndex].nowMent].charNumber].Name);
            textCon.UpdateDial(dataSet.dialogue[dataSet.currentDialogueIndex].DialogueData);
        }


    }

}
