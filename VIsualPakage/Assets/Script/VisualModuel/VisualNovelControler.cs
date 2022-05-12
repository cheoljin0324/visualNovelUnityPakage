using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovelControler : MonoBehaviour
{
    VisualSet dataSet;
    ObjectSet objectSet;
    CharacterObjectSet characterObjectSet;
    ObjectInFade objectInFade;
    ObjectSetPosition objectSetPosition;
    CharacterObjectSpriteSet characterObjectSpriteSet;

    void Awake()
    {
        objectSet = GameObject.Find("ObjectSetOb").GetComponent<ObjectSet>();
        characterObjectSet = GameObject.Find("CharSet").GetComponent<CharacterObjectSet>();
        objectInFade = GameObject.Find("CharSet").GetComponent<ObjectInFade>();
        objectSetPosition = GameObject.Find("CharSet").GetComponent<ObjectSetPosition>();
        characterObjectSpriteSet = GameObject.Find("CharSet").GetComponent<CharacterObjectSpriteSet>();
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
                if(dataSet.dialogue.Length> dataSet.currentDialogueIndex + 1)
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
            characterObjectSet.DelObject();
        }
        characterObjectSet.NewObject(dataSet.dialogue[dataSet.currentDialogueIndex].charSet.Length);
        objectSetPosition.SetPos(dataSet.dialogue[dataSet.currentDialogueIndex].charintPos);
        SpriteSet();
        objectInFade.ObIn();

    }


    void SpriteSet()
    {
        if (dataSet.dialogue[dataSet.currentDialogueIndex].charSet.Length == 1)
        {
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].Emotion]);
        }
        else if (dataSet.dialogue[dataSet.currentDialogueIndex].charSet.Length == 2)
        {
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].Emotion]);
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[1].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[1].Emotion]);
        }
        else if (dataSet.dialogue[dataSet.currentDialogueIndex].charSet.Length == 3)
        {
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[0].Emotion]);
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[1].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[1].Emotion]);
            characterObjectSpriteSet.SpriteSet(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[2].charNumber].charSprite[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[2].Emotion]);
        }
    }

}
