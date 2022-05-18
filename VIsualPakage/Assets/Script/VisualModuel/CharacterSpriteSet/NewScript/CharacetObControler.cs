using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacetObControler : MonoBehaviour
{
    //ĳ���� �ϱ� ���� Ŭ���� ������
    //VisualSet �����͸� ���� �´�
    VisualSet dataset;
    //ĳ���� ������Ʈ ����
    InstCharacterOb InstChar;
    //ĳ���� ��ġ �ʱ�ȭ
    CharacterSetPos charPos;
    //���̾� ��������Ʈ�� �ʱ�ȭ
    DialSpriteSet dialSpriteSet;
    //������Ʈ ����
    DelOb deleteObject;
    //ĳ���� ������Ʈ ����Ʈ
    List<List<GameObject>> CharGroup = new List<List<GameObject>>();

    private void Awake()
    {
        //ĳ��
        dataset = GetComponent<VisualSet>();
        InstChar = GameObject.Find("CharacterSetManager").GetComponent<InstCharacterOb>();
        charPos = GameObject.Find("CharacterSetManager").GetComponent<CharacterSetPos>();
        dialSpriteSet = GameObject.Find("CharacterSetManager").GetComponent<DialSpriteSet>();
        deleteObject = GameObject.Find("CharacterSetManager").GetComponent<DelOb>();

    }

    /// <summary>
    /// ĳ���� ����
    /// </summary>
    public void CreaterCharacetOb()
    {
        //�������� ���̾�α� ������ �� ��ŭ ĳ���͸� ���� �� ��������Ʈ�� �ʱ�ȭ
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            InstChar.InstantiateObject(dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite.Length,CharGroup);
            dialSpriteSet.SpriteSet(CharGroup[i], dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite);
        }
    }

    /// <summary>
    /// �̸�� ��������Ʈ ��
    /// </summary>
    public void EmotionSprite()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            dialSpriteSet.SpriteSet(CharGroup[i], dataset.simChar[dataset.dialogue[dataset.currentDialogueIndex].charSet[i].charNumber].charSprite);
        }
    }

    /// <summary>
    /// ���� �ٲ� ����� ���̵� ȿ��
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
    /// ������Ʈ ���� �ɶ� ���̵� ȿ��
    /// </summary>
    public void DelFade()
    {
        for (int i = 0; i < dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(0f, 1f);
        }
    }

    /// <summary>
    /// ������Ʈ �����ɶ� ���̵� ȿ��
    /// </summary>
    public void CreateFade()
    {
        for(int i = 0; i<dataset.dialogue[dataset.currentDialogueIndex].charSet.Length; i++)
        {
            CharGroup[i][dataset.dialogue[dataset.currentDialogueIndex].charSet[i].Emotion].GetComponent<SpriteRenderer>().DOFade(1f, 1f);
        }
    }

    /// <summary>
    /// ĳ���� ����
    /// </summary>
    public void CharDel()
    {
        for(int i = 0; i<CharGroup.Count; i++)
        {
            deleteObject.DeleteOB(CharGroup[i]);
        }
    }

    /// <summary>
    /// ������Ʈ ��ġ ����
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
    /// ������Ʈ ����
    /// </summary>
    /// <param name="j"></param>
    /// <returns></returns>
    IEnumerator TransposN(int j)
    {
        yield return new WaitForSeconds(0.5f);
        SetPos(j);
    }

    /// <summary>
    /// ������Ʈ ��ġ �ʱ�ȭ
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
