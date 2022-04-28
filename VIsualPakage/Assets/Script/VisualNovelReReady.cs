using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VisualNovelReReady : MonoBehaviour
{
    public EventCGSet[] eventCGSets;
    public Character[] useCharacter;
    public BackScreen[] backScreen;
    public DialogueM[] dialogueMs;

    private string playerName = "";
    private bool isFirst = true;
    private bool isAuto = true;
    private int currentDialogueIndex = -1;
    private int[] currentCharIndex = new int[3];
    private int currentMentCharIndex = 0;
    private float typingSpd = 0.03f;
    private bool isTyping = false;

    private void Awake()
    {
        currentCharIndex[0] = dialogueMs[currentDialogueIndex + 1].charSet[0].charNumber;
        currentCharIndex[1]= dialogueMs[currentDialogueIndex + 1].charSet[1].charNumber;
        currentCharIndex[2]= dialogueMs[currentDialogueIndex + 1].charSet[2].charNumber;
        SetScreen();
    }

    private void SetScreen()
    {
        for(int i = 0; i<useCharacter.Length; ++i)
        {
            SetObjects(useCharacter[i], false);
        }
    }

    public bool UpdateDialogue()
    {
        if(isFirst == true)
        {
            SetScreen();
            if (isAuto) SetNextDialogue();
            isFirst = false;
        }

        if(isTyping == true)
        {
            isTyping = false;
            StopCoroutine("Ontyping");
            useCharacter[currentMentCharIndex].dialogueText.text = dialogueMs[currentDialogueIndex].DialogueData;
            useCharacter[currentMentCharIndex].Arrow.gameObject.SetActive(true);
        }

        if (dialogueMs.Length > currentDialogueIndex + 1)
        {
            SetNextDialogue();
        }
        else
        {
            for(int i = 0; i < useCharacter.Length; ++i)
            {
                SetObjects(useCharacter[i],false);
            }
            return true;
        }
        return false;
    }

    public void SetNextDialogue()
    {
        SetObjects(useCharacter[dialogueMs[currentDialogueIndex].charSet[0].charNumber], false);
        SetObjects(useCharacter[dialogueMs[currentDialogueIndex].charSet[1].charNumber], false);
        SetObjects(useCharacter[dialogueMs[currentDialogueIndex].charSet[2].charNumber], false);

        currentDialogueIndex++;

        currentCharIndex[0] = dialogueMs[currentDialogueIndex].charSet[0].charNumber;
        currentCharIndex[1] = dialogueMs[currentDialogueIndex].charSet[1].charNumber;
        currentCharIndex[2] = dialogueMs[currentDialogueIndex].charSet[2].charNumber;

        dialogueMs[currentDialogueIndex].DialogueData = dialogueMs[currentDialogueIndex].DialogueData.Replace("/플레이어/", name);
        currentMentCharIndex = dialogueMs[currentDialogueIndex].nowMent;

        useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].sprite = useCharacter[currentCharIndex[0]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[0].Emotion].charSprite;
        if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
        {
            useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].sprite = useCharacter[currentCharIndex[1]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[1].Emotion].charSprite;
        }
        if(dialogueMs[currentDialogueIndex].charSet.Length > 2)
        {
            useCharacter[currentCharIndex[2]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].sprite = useCharacter[currentCharIndex[2]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[2].Emotion].charSprite;
        }
        SetObjects(useCharacter[0], true);
        SetObjects(useCharacter[1], true);
        SetObjects(useCharacter[2], true);

        if (useCharacter[currentMentCharIndex].Name == "/플레이어/")
        {
            useCharacter[currentMentCharIndex].Name = playerName;
        }

        useCharacter[currentMentCharIndex].nameText.text = useCharacter[currentMentCharIndex].Name;
        useCharacter[currentMentCharIndex].dialogueText.text = dialogueMs[currentDialogueIndex].DialogueData;
        StartCoroutine("OnTyping");
    }

    private void SetObjects(Character useChar,bool visable)
    {

    }
    private void SetObjects(EventCGSet eventCG,bool visable)
    {

    }

}



/*--------------------------------------------------------------------------------------------------------------------------------------*/



//사용할 캐릭터 스프라이트를 정리해놓은 구조체(charSprite(sprite),stringEmotionName(string))
[System.Serializable]
public struct CharSpriteSet
{
    [Header("캐릭터 스프라이트 목록")]
    public Sprite charSprite;
    [Header("캐릭터 해당 스프라이트 이름")]
    public string EmotionName;
}

//사용할 이벤트 CG(EventCG(sprite),CGName(string)
[System.Serializable]
public struct EventCGSet
{
    [Header("사용할 이벤트 CG")]
    public Sprite EventCG;
    [Header("CG이름")]
    public string CGName;
}

//배경 정리(backSprite(Sprite), backName(string))
[System.Serializable]
public struct BackScreen
{
    [Header("사용할 배경")]
    public Sprite backSprite;

    [Header("문자열")]
    public string backName;
}

//캐릭터 정리(Name(string),charSpriteSet(CharSpriteSet[]),dialRender(SpriteRenderer),dialogueText(Text),Arrow(SpriteRenderer))
[System.Serializable]
public struct Character
{
    [Header("이름")]
    public string Name;
    [Header("캐릭터 이미지 분류")]
    public CharSpriteSet[] charSpriteSet;
    [Header("캐릭터 스프라이트 렌더러")]
    public SpriteRenderer[] spriteRenderers;
    [Header("사용하는 대화창")]
    public SpriteRenderer dialRender;

    [Header("사용할 텍스트 Name")]
    public Text nameText;
    [Header("사용할 텍스트 Dial")]
    public Text dialogueText;

    [Header("오브젝트 방향키")]
    public SpriteRenderer Arrow;
}

//DialogueM 에서 사용하는 캐릭터 아이디를 불러오는 곳을 구조화 시킨 것(charNumber(int),Emotion(string))
[System.Serializable]
public struct CharSet
{
    [Header("사용 캐릭터(정수)")]
    public int charNumber;
    [Header("사용 감정(문자)")]
    public int Emotion;
}

//다이얼로그(dialogueEvent(DialogueEvent),DialogueData(string),charSet(CharSet[]),isAngry(bool),backName(string),useVideo(VideoClip),audioClip(AudioClip),EventCGSprite(string))
[System.Serializable]
public struct DialogueM
{
    public enum DialogueEvent { NormalDial, EventCG, VideoCG }

    [Header("대화 형태")]
    public DialogueEvent dialogueEvent;

    [Header("대화")]
    [TextArea(3, 5)]
    public string DialogueData;

    [Header("캐릭터 자료")]
    public CharSet[] charSet;
    [Header("위치")]
    public int[] charintPos;
    [Header("말을 하는 유저")]
    public int nowMent;

    [Header("화난 효과")]
    public bool isAngry;
    [Header("사용할 배경")]
    public string backName;

    [Header("사용할 비디오")]
    public VideoClip useVideo;

    [Header("더빙")]
    public AudioClip audioClip;

    [Header("사용할 이벤트 CG")]
    public string EventCGSprite;


}
