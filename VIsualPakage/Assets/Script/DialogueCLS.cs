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

    [Header("다이얼로그")]
    public List<DialogueStruct> dialogueStructs;

    [Header("배경")]
    public List<BackGround> backGroundList;


    


}

[System.Serializable]
public struct Character
{
    [Header("캐릭터 이름")]
    public string characterName;
    [Header("캐릭터 메인 그림")]
    public Sprite charracterSprite;
    [Header("사용 될 주소")]
    public string _ID;
    [Header("캐릭터 감정")]
    public Sprite[] charracterImotion;
}

[System.Serializable]
public struct BackGround
{
    [Header("배경")]
    public Sprite backGround;
    [Header("배경의 이름")]
    public string backName;
    
}

public enum HumanCount
{
    One,Two,Three
}

