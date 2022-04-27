using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public enum DialogueType
{
    None,NormalCG,EventCg
}

public class DialogueCLS : MonoBehaviour
{
    [System.Serializable]
    public struct DialogueStruct
    {
        public DialogueType typeVisual;


        public int humanCount;
        public string backName;

        //public int IDnum;
        //public int SIDnum;
        //public string TIDnum;
        //public int _emotionNum;
        //public int _SemotionNum;
        //public int _TemotionNum;
        //public Sprite CGSprite;


    }
    public DialogueStruct dialogueStruct { get; set;}

    [Header("���̾�α�")]
    public List<DialogueStruct> dialogueStructs;

    [Header("���")]
    public List<BackGround> backGroundList;


    


}

[System.Serializable]
public struct Character
{
    [Header("ĳ���� �̸�")]
    public string characterName;
    [Header("ĳ���� ���� �׸�")]
    public Sprite charracterSprite;
    [Header("��� �� �ּ�")]
    public string _ID;
    [Header("ĳ���� ����")]
    public Sprite[] charracterImotion;
}

[System.Serializable]
public struct BackGround
{
    [Header("���")]
    public Sprite backGround;
    [Header("����� �̸�")]
    public string backName;
    
}

public enum HumanCount
{
    One,Two,Three
}

