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

    void Awake()
    {
        objectSet = GameObject.Find("ObjectSetOb").GetComponent<ObjectSet>();
        characterObjectSet = GameObject.Find("CharSet").GetComponent<CharacterObjectSet>();
        objectInFade = GameObject.Find("CharSet").GetComponent<ObjectInFade>();
        objectSetPosition = GameObject.Find("CharSet").GetComponent<ObjectSetPosition>();
        characterObjectSpriteSet = GameObject.Find("CharSet").GetComponent<CharacterObjectSpriteSet>();
        objectOutFade = GameObject.Find("CharSet").GetComponent<ObjectOutFade>();
        dialControl = GameObject.Find("ObjectSetOb").GetComponent<DialogueControler>();
        dataSet = GetComponent<VisualSet>();
    }

    public bool UpdateDialogue()
    {
        if (dataSet.isFirst == true)
        {
            SetNextDialogue();
            dataSet.isFirst = false;
        }

        else
        {
            if (Input.GetMouseButtonUp(0))
            {
               
                    if (dataSet.dialogue.Length > dataSet.currentDialogueIndex + 1)
                    {
                        SetNextDialogue();
                    }
                    else
                    {
                        return true;
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
            if (dataSet.currentDialogueIndex == dataSet.dialogue.Length)
            {
                characterObjectSet.fadeTime = 0.5f;
            }
            else
            {
                characterObjectSet.fadeTime = 0.1f;
            }
            objectOutFade.ObOut();
            characterObjectSet.DelObject();
            Debug.Log(characterObjectSet.ObjectList.Count);
        }
        else
        {
            dialControl.NewDial(objectSet.DialBox);
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
        objectInFade.ObIn();
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
