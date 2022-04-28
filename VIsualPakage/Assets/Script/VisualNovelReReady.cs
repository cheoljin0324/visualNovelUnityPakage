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

        dialogueMs[currentDialogueIndex].DialogueData = dialogueMs[currentDialogueIndex].DialogueData.Replace("/�÷��̾�/", name);
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

        if (useCharacter[currentMentCharIndex].Name == "/�÷��̾�/")
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



//����� ĳ���� ��������Ʈ�� �����س��� ����ü(charSprite(sprite),stringEmotionName(string))
[System.Serializable]
public struct CharSpriteSet
{
    [Header("ĳ���� ��������Ʈ ���")]
    public Sprite charSprite;
    [Header("ĳ���� �ش� ��������Ʈ �̸�")]
    public string EmotionName;
}

//����� �̺�Ʈ CG(EventCG(sprite),CGName(string)
[System.Serializable]
public struct EventCGSet
{
    [Header("����� �̺�Ʈ CG")]
    public Sprite EventCG;
    [Header("CG�̸�")]
    public string CGName;
}

//��� ����(backSprite(Sprite), backName(string))
[System.Serializable]
public struct BackScreen
{
    [Header("����� ���")]
    public Sprite backSprite;

    [Header("���ڿ�")]
    public string backName;
}

//ĳ���� ����(Name(string),charSpriteSet(CharSpriteSet[]),dialRender(SpriteRenderer),dialogueText(Text),Arrow(SpriteRenderer))
[System.Serializable]
public struct Character
{
    [Header("�̸�")]
    public string Name;
    [Header("ĳ���� �̹��� �з�")]
    public CharSpriteSet[] charSpriteSet;
    [Header("ĳ���� ��������Ʈ ������")]
    public SpriteRenderer[] spriteRenderers;
    [Header("����ϴ� ��ȭâ")]
    public SpriteRenderer dialRender;

    [Header("����� �ؽ�Ʈ Name")]
    public Text nameText;
    [Header("����� �ؽ�Ʈ Dial")]
    public Text dialogueText;

    [Header("������Ʈ ����Ű")]
    public SpriteRenderer Arrow;
}

//DialogueM ���� ����ϴ� ĳ���� ���̵� �ҷ����� ���� ����ȭ ��Ų ��(charNumber(int),Emotion(string))
[System.Serializable]
public struct CharSet
{
    [Header("��� ĳ����(����)")]
    public int charNumber;
    [Header("��� ����(����)")]
    public int Emotion;
}

//���̾�α�(dialogueEvent(DialogueEvent),DialogueData(string),charSet(CharSet[]),isAngry(bool),backName(string),useVideo(VideoClip),audioClip(AudioClip),EventCGSprite(string))
[System.Serializable]
public struct DialogueM
{
    public enum DialogueEvent { NormalDial, EventCG, VideoCG }

    [Header("��ȭ ����")]
    public DialogueEvent dialogueEvent;

    [Header("��ȭ")]
    [TextArea(3, 5)]
    public string DialogueData;

    [Header("ĳ���� �ڷ�")]
    public CharSet[] charSet;
    [Header("��ġ")]
    public int[] charintPos;
    [Header("���� �ϴ� ����")]
    public int nowMent;

    [Header("ȭ�� ȿ��")]
    public bool isAngry;
    [Header("����� ���")]
    public string backName;

    [Header("����� ����")]
    public VideoClip useVideo;

    [Header("����")]
    public AudioClip audioClip;

    [Header("����� �̺�Ʈ CG")]
    public string EventCGSprite;


}
