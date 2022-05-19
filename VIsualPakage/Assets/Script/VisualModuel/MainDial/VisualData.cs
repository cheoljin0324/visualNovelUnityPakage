using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//사용되는 데이터 구조체 정의
[System.Serializable]
public struct DialogueIs
{
    public enum DialogueEven { NormalDial, EventCG, VideoCG }

    [Header("대화 형태")]
    public DialogueEven dialogueEvent;

    [Header("대화")]
    [TextArea(3, 5)]
    public string DialogueData;

    [Header("캐릭터 자료")]
    public CharSet[] charSet;
    [Header("위치")]
    public int[] charintPos;
    [Header("말을 하는 유저")]
    public int nowMent;
    [Header("줌 인")]
    public bool zoom;

    [Header("화난 효과")]
    public bool isAngry;
    [Header("사용할 배경")]
    public int backName;

    [Header("더빙")]
    public AudioClip audioClip;

    [Header("사용할 이벤트 CG")]
    public int EventCGSprite;


}

[System.Serializable]
public struct EventSet
{
    [Header("사용할 CG렌더러")]
    public SpriteRenderer eventRenderer;
    [Header("다이얼로그 박스")]
    public SpriteRenderer dialogueEvent;
    [Header("다이얼 네임- 텍스트")]
    public Text nameText;
    [Header("다이얼 텍스트")]
    public Text dialText;
    [Header("사용할 이벤트 CG")]
    public Sprite EventCG;
    [Header("이벤트 CG 다이얼 종료")]
    public SpriteRenderer Arrow;
    [Header("CG이름")]
    public int CGName;
}



[System.Serializable]
public struct SimCharacter
{
    [Header("이름")]
    public string Name;
    [Header("캐릭터 스프라이트 목록")]
    public Sprite[] charSprite;
}
