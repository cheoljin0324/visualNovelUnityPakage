using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacetObControler : MonoBehaviour
{
    //캐싱을 하기 위한 클래스 변수들
    //VisualSet 데이터를 갖고 온다
    VisualSet dataset;
    //캐릭터 오브젝트 생성
    InstCharacterOb InstChar;
    //캐릭터 위치 초기화
    CharacterSetPos charPos;
    //다이얼 스프라이트를 초기화
    DialSpriteSet dialSpriteSet;
    //오브젝트 삭제
    DelOb deleteObject;
    //캐릭터 오브젝트 리스트
    List<List<GameObject>> CharGroup = new List<List<GameObject>>();

    private void Awake()
    {
        //캐싱
        dataset = GetComponent<VisualSet>();
        InstChar = GameObject.Find("CharacterSetManager").GetComponent<InstCharacterOb>();
        charPos = GameObject.Find("CharacterSetManager").GetComponent<CharacterSetPos>();
        dialSpriteSet = GameObject.Find("CharacterSetManager").GetComponent<DialSpriteSet>();
        deleteObject = GameObject.Find("CharacterSetManager").GetComponent<DelOb>();

    }

    /// <summary>
    /// 캐릭터 생성
    /// </summary>
    public void CreaterCharacetOb()
    {
        //데이터의 다이얼로그 데이터 값 만큼 캐릭터를 생성 후 스프라이트를 초기화
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            InstChar.InstantiateObject(dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite.Length,CharGroup);
            dialSpriteSet.SpriteSet(CharGroup[i], dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite);
        }
    }

    /// <summary>
    /// 이모션 스프라이트 셋
    /// </summary>
    public void EmotionSprite()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            dialSpriteSet.SpriteSet(CharGroup[i], dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite);
        }
    }

    /// <summary>
    /// 감정 바뀔때 생기는 페이드 효과
    /// </summary>
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

    /// <summary>
    /// 오브젝트 삭제 될때 페이드 효과
    /// </summary>
    public void DelFade()
    {
        for (int i = 0; i < dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(0f, 1f);
        }
    }

    /// <summary>
    /// 오브젝트 생성될때 페이드 효과
    /// </summary>
    public void CreateFade()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(1f, 1f);
        }
    }

    /// <summary>
    /// 캐릭터 삭제
    /// </summary>
    public void CharDel()
    {
        for(int i = 0; i<CharGroup.Count; i++)
        {
            deleteObject.DeleteOB(CharGroup[i]);
        }
    }

    /// <summary>
    /// 오브젝트 위치 변경
    /// </summary>
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

    /// <summary>
    /// 오브젝트 변경
    /// </summary>
    /// <param name="j"></param>
    /// <returns></returns>
    IEnumerator TransposN(int j)
    {
        yield return new WaitForSeconds(0.5f);
        SetPos(j);
    }

    /// <summary>
    /// 오브젝트 위치 초기화
    /// </summary>
    /// <param name="SetNum"></param>
    public void SetPos(int SetNum)
    {
        
            for(int j = 0; j<CharGroup[SetNum].Count; j++)
            {
                charPos.SetPosition(dataset.dialogue[dataset.currentDialogueIndex].charintPos[SetNum], CharGroup[SetNum][j]);
            }

        
        
    }
}
