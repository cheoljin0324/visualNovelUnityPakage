using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovelControler : MonoBehaviour
{
    VisualSet dataSet;
    ObjectSet objectSet;
    CharacterObjectSet characterObjectSet;
    ObjectInFade objectInFade;
    ObjectOutFade objectOutFade;
    ObjectSetPosition objectSetPosition;
    CharacterObjectSpriteSet characterObjectSpriteSet;
    DialogueControler dialControl;
    TextControler textCon;
    CharacetObControler CharCon;

    public bool isFade = false;

    void Awake()
    {
        objectSet = GameObject.Find("ObjectSetOb").GetComponent<ObjectSet>();
        characterObjectSet = GameObject.Find("CharSet").GetComponent<CharacterObjectSet>();
        objectInFade = GameObject.Find("CharSet").GetComponent<ObjectInFade>();
        objectSetPosition = GameObject.Find("CharSet").GetComponent<ObjectSetPosition>();
        characterObjectSpriteSet = GameObject.Find("CharSet").GetComponent<CharacterObjectSpriteSet>();
        objectOutFade = GameObject.Find("CharSet").GetComponent<ObjectOutFade>();
        dialControl = GameObject.Find("ObjectSetOb").GetComponent<DialogueControler>();
        textCon = GameObject.Find("TextManager").GetComponent<TextControler>();
        CharCon = GetComponent<CharacetObControler>();
        dataSet = GetComponent<VisualSet>();
    }

    public void Start()
    {
        CharCon.CreaterCharacetOb();
        CharCon.SetPos(0);
        CharCon.SetPos(1);
        StartCoroutine("DelOB");
    }

    IEnumerator DelOB()
    {
        yield return new WaitForSeconds(3f);
        CharCon.CharDel();
    }

    public bool UpdateDialogue()
    {
        if (dataSet.isFirst == true)
        {
            characterObjectSet.fadeTime = 0.1f;
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
                        for (int i = 0; i < characterObjectSet.ObjectList.Count; i++)
                        {
                            characterObjectSet.fadeTime = 1f;
                            isFade = true;
                            objectOutFade.ObOut(i);
                            textCon.DeleteDial();
                            textCon.DeleteName();
                        }
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
                characterObjectSet.fadeTime = 1f;
            }
            else
            {
                characterObjectSet.fadeTime = 0.1f;
            }
            for(int i = 0; i<characterObjectSet.ObjectList.Count; i++)
            {
                if(dataSet.dialogue[dataSet.currentDialogueIndex].charSet[i].Emotion!= dataSet.dialogue[dataSet.currentDialogueIndex-1].charSet[i].Emotion||dataSet.dialogue[dataSet.currentDialogueIndex].charintPos[i]!= dataSet.dialogue[dataSet.currentDialogueIndex-1].charintPos[i])
                {
                    isFade = true;
                    objectOutFade.ObOut(i);
                }

            }
            if (isFade == false||dataSet.currentDialogueIndex==1)
            {
                characterObjectSet.fadeTime = 0;
            }
            characterObjectSet.DelObject(dataSet.dialogue[dataSet.currentDialogueIndex-1].charSet.Length);
            Debug.Log(characterObjectSet.ObjectList.Count);
        }
        else
        {
            dialControl.NewDial(objectSet.DialBox);
            textCon.InstName();
            textCon.InstDial();
            textCon.UpdateName(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[dataSet.dialogue[dataSet.currentDialogueIndex].nowMent].charNumber].Name);
            textCon.UpdateDial(dataSet.dialogue[dataSet.currentDialogueIndex].DialogueData);
        }
        StartCoroutine(NewOb());

           



    }

    IEnumerator NewOb()
    {
        yield return new WaitForSeconds(0.5f);
        
        characterObjectSet.NewObject(dataSet.dialogue[dataSet.currentDialogueIndex].charSet.Length);
        Debug.Log(characterObjectSet.ObjectList.Count);
        objectSetPosition.SetPos(dataSet.dialogue[dataSet.currentDialogueIndex].charintPos);
        SpriteSet();
        for (int i = 0; i < characterObjectSet.ObjectList.Count; i++)
        {
            if (dataSet.currentDialogueIndex == 0)
            {
                objectInFade.ObIn(i);
            }
            else
            {
                if (dataSet.dialogue[dataSet.currentDialogueIndex].charSet[i].Emotion != dataSet.dialogue[dataSet.currentDialogueIndex-1].charSet[i].Emotion || dataSet.dialogue[dataSet.currentDialogueIndex].charintPos[i] != dataSet.dialogue[dataSet.currentDialogueIndex-1].charintPos[i])
                {
                    objectInFade.ObIn(i);
                    isFade = false;
                }
                else
                {
                    characterObjectSet.ObjectList[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    characterObjectSet.fadeTime = 0.1f;
                }
            }

            

        }
        dataSet.isLastDial = true;
    }

    void SpriteSet()
    {
        if (dataSet.dialogue[dataSet.currentDialogueIndex].charSet.Length == 1)
        {
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].Emotion]);
        }
        else if (dataSet.dialogue[dataSet.currentDialogueIndex].charSet.Length == 2)
        {
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].Emotion], dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[1].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[1].Emotion]);
        }
        else if (dataSet.dialogue[dataSet.currentDialogueIndex].charSet.Length == 3)
        {
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].Emotion], dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[1].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[1].Emotion], dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[2].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[2].Emotion]);

        }
    }

}
