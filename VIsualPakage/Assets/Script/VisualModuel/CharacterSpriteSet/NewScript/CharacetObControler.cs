using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

    public void EmotionSprite()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            dialSpriteSet.SpriteSet(CharGroup[i], dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite);
        }
    }

    public void EmotionFade()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            if(dataset.dialogue[dataset.currentDialogueIndex].charSet[i].Emotion != dataset.dialogue[dataset.currentDialogueIndex-1].charSet[i].Emotion)
            {
                CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex-1].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(0f, 0.1f);
                CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(1f, 0.2f);
            }
        }
    }

    public void DelFade()
    {
        for (int i = 0; i < dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(0f, 1f);
        }
    }

    public void CreateFade()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(1f, 1f);
        }
    }

    public void CharDel()
    {
        for(int i = 0; i<CharGroup.Count; i++)
        {
            deleteObject.DeleteOB(CharGroup[i]);
        }
    }

    public void TransPos()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charintPos.Length; i++)
        {
            if (dataset.dialogue[dataset.currentDialogueIndex].charintPos[i] != dataset.dialogue[dataset.currentDialogueIndex - 1].charintPos[i])
            {
                CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex - 1].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(0f, 0.5f);
                for(int j = 0; j<CharGroup[i].Count; i++)
                {
                    StartCoroutine(TransposN(j));
                }
            }
        }
    }

    IEnumerator TransposN(int j)
    {
        yield return new WaitForSeconds(0.5f);
        SetPos(j);
    }

    public void SetPos(int SetNum)
    {
        
            for(int j = 0; j<CharGroup[SetNum].Count; j++)
            {
                charPos.SetPosition(dataset.dialogue[dataset.currentDialogueIndex].charintPos[SetNum], CharGroup[SetNum][j]);
            }

        
        
    }
}
