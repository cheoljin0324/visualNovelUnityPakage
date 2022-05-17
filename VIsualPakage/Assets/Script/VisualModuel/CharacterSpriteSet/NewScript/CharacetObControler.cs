using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacetObControler : MonoBehaviour
{
    VisualSet dataset;
    InstCharacterOb InstChar;
    CharacterSetPos charPos;
    DialSpriteSet dialSpriteSet;
    DelOb deleteObject;
    List<List<GameObject>> CharGroup = new List<List<GameObject>>();

    private void Awake()
    {
        dataset = GetComponent<VisualSet>();
        InstChar = GameObject.Find("CharacterSetManager").GetComponent<InstCharacterOb>();
        charPos = GameObject.Find("CharacterSetManager").GetComponent<CharacterSetPos>();
        dialSpriteSet = GameObject.Find("CharacterSetManager").GetComponent<DialSpriteSet>();
        deleteObject = GameObject.Find("CharacterSetManager").GetComponent<DelOb>();

    }



    public void CreaterCharacetOb()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            InstChar.InstantiateObject(dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite.Length,CharGroup);
            dialSpriteSet.SpriteSet(CharGroup[i], dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite);
        }
    }

    public void CharDel()
    {
        for(int i = 0; i<CharGroup.Count; i++)
        {
            deleteObject.DeleteOB(CharGroup[i]);
        }
    }



    public void SetPos(int SetNum)
    {
        
            for(int j = 0; j<CharGroup[SetNum].Count; j++)
            {
                charPos.SetPosition(dataset.dialogue[dataset.currentDialogueIndex].charintPos[SetNum], CharGroup[SetNum][j]);
            }

        
        
    }
}
