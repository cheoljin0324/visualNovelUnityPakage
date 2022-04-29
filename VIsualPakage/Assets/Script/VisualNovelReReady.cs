using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;

public class VisualNovelReReady : MonoBehaviour
{
    //��� �� �̺�Ʈ CG
    public EventCGSet[] eventCGSets;
    //��� �� ĳ����
    public Character[] useCharacter;
    //���� ���
    public BackScreen[] backScreen;
    //���� ���̾�α� �Ӽ�
    public DialogueM[] dialogueMs;

    //���� �̸�
    private string playerName = "";
    //���̾�α��� ù ��ŸƮ �α��ΰ�?
    private bool isFirst = true;
    //�ڵ����� ������ �Ǵ°�?
    private bool isAuto = true;
    //���� ���̾�α� ���൵
    private int currentDialogueIndex = -1;
    //ĳ���� ����(�ִ� 3��)
    private int[] currentCharIndex = new int[3];
    //���� ���ϰ� �ִ� ĳ���� ����
    private int currentMentCharIndex = 0;
    //Ÿ���� ȿ������ ���� Ÿ���� �ӵ�
    private float typingSpd = 0.03f;
    //Ÿ������ ���� �������ΰ�?
    private bool isTyping = false;
    //���� ������� �̺�ƮCG
    private int currenteventCG;

    private void Awake()
    {
        //�ʱ� ������ ������ ���Ǵ� ĳ���� ���� �ʱ�ȭ
        currentCharIndex[0] = dialogueMs[currentDialogueIndex + 1].charSet[0].charNumber;
        if (dialogueMs[currentDialogueIndex+1].charSet.Length > 1)
        {
            currentCharIndex[1] = dialogueMs[currentDialogueIndex + 1].charSet[1].charNumber;
        }
        if (dialogueMs[currentDialogueIndex+1].charSet.Length > 2)
        {
            currentCharIndex[2] = dialogueMs[currentDialogueIndex + 1].charSet[2].charNumber;
        }
        
        if (dialogueMs[currentDialogueIndex + 1].dialogueEvent == DialogueM.DialogueEvent.EventCG)
        {
            currenteventCG = dialogueMs[currentDialogueIndex + 1].EventCGSprite;
        }
        //�ʱ�ȭ
        SetScreen();
    }

    /// <summary>
    /// �ʱ�ȭ �Լ�
    /// </summary>
    private void SetScreen()
    {
        //ĳ���Ϳ� ����ִ� ĳ���� ��ŭ
        for(int i = 0; i<useCharacter.Length; ++i)
        {
            //ĳ���� �ִ� �͵��� ������ ���� �켱 ���ش�.
            SetObjects(useCharacter[i], false);
   
        }
        //CG����ִ� ��ŭ
        if (eventCGSets.Length > 0)
        {
            for (int i = 0; i < eventCGSets.Length; ++i)
            {
                //CG������Ʈ ���� �����ش�.
                SetObjects(eventCGSets[i], false);
            }
        }
        
    }

    /// <summary>
    /// ���� ���̴� ���̾�α׸� ������Ʈ
    /// </summary>
    public bool UpdateDialogue()
    {
        //���� ù ��° ��ȭâ�ΰ�?
        if(isFirst == true)
        {
            //�ʱ�ȭ
            SetScreen();
            //�ڵ� ������ ��� �ڵ����� ���� ��ȭ ����
            if (isAuto) SetNextDialogue();
            //�� ���ķ� ó���� �ƴϱ⿡ ó�� ���� �������� ����
            isFirst = false;
        }

        //���� ���콺 ��ư(0)�� ���� ���
        if (Input.GetMouseButtonDown(0))
        {
            //���� Ÿ���� �����̾��ٸ�
            if (isTyping == true)
            {
                //Ÿ������ ����
                isTyping = false;
                //Ÿ���� �ϰ� �ִ� �ڷ�ƾ�� ����
               // StopCoroutine("Ontyping");
                //Ÿ���� �ϴ� �ؽ�Ʈ�� ���������� ��ȭ �ϼ������� �ʱ�ȭ
                useCharacter[currentMentCharIndex].dialogueText.text = dialogueMs[currentDialogueIndex].DialogueData;
                //�����ٴ� ȭ��ǥ�� ǥ��
                useCharacter[currentMentCharIndex].Arrow.gameObject.SetActive(true);
            }

            //���� �̰� ������ ��ȭâ�� �ƴ� ���
            if (dialogueMs.Length > currentDialogueIndex + 1)
            {
                //���� ��ȭâ ����
                SetNextDialogue();
            }
            //���� �̰� ������ ��ȭâ�� ���
            else
            {
                //��� ĳ���Ϳ� �ִ� ��ġ��
                for (int i = 0; i < useCharacter.Length; ++i)
                {
                    //����
                    SetObjects(useCharacter[i], false);
                }
                if (eventCGSets.Length > 0)
                {
                    for (int i = 0; i < eventCGSets.Length; i++)
                    {
                        SetObjects(eventCGSets[i], false);
                    }
                }
               
                //Ʈ�縦 ��ȯ�ϸ鼭 ���� �Լ� ����ǰ� ��
                return true;
            }
        }
        //�ƴ� ���� �׻� false�� �ش� �Լ��� �ӹ��� ��
        return false;
    }

    /// <summary>
    /// ���� ��ȭ ����
    /// </summary>
    public void SetNextDialogue()
    {
        currentDialogueIndex++;

        //���� ��ȭâ�� �ִ� ������ ���� ����
        currentCharIndex[0] = dialogueMs[currentDialogueIndex].charSet[0].charNumber;
        if(dialogueMs[currentDialogueIndex].charSet.Length > 1)
        {
            currentCharIndex[1] = dialogueMs[currentDialogueIndex].charSet[1].charNumber;
        }

        if (dialogueMs[currentDialogueIndex].charSet.Length > 2)
        {
            currentCharIndex[2] = dialogueMs[currentDialogueIndex].charSet[2].charNumber;
        }

        if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.EventCG)
        {
            currentDialogueIndex = dialogueMs[currentDialogueIndex].EventCGSprite;
        }
        

        //���� ���� ��ȭ ���� �� /�÷��̾�/ ��� Ű���尡 ������ �� ���� �������� �̸����� ����
        dialogueMs[currentDialogueIndex].DialogueData = dialogueMs[currentDialogueIndex].DialogueData.Replace("/�÷��̾�/", playerName);
        //���� ��ȭ �ϰ� �ִ� �ι��� ���� ����
        currentMentCharIndex = dialogueMs[currentDialogueIndex].nowMent;

        //���Ǵ� ĳ���Ϳ� �ִ� ��������Ʈ �������� ����
        useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].sprite = useCharacter[currentCharIndex[0]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[0].Emotion].charSprite;
        //���� ���Ǵ� ĳ���Ͱ� 1���� ������
        if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
        {
            //�ι�° ĳ���� ����
            useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].sprite = useCharacter[currentCharIndex[1]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[1].Emotion].charSprite;
        }
        //3�� ���� ������
        if(dialogueMs[currentDialogueIndex].charSet.Length > 2)
        {
            //3����� ����
            useCharacter[currentCharIndex[2]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].sprite = useCharacter[currentCharIndex[2]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[2].Emotion].charSprite;
        }

        //������Ʈ�� ���� ���ش�.
        SetObjects(useCharacter[dialogueMs[currentDialogueIndex].charSet[0].charNumber], true);
        //���� 1���� ������
        if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
        {
          SetObjects(useCharacter[dialogueMs[currentDialogueIndex].charSet[1].charNumber], true);
        }
        //���� 2���� ������
        if (dialogueMs[currentDialogueIndex].charSet.Length > 2)
        {
            SetObjects(useCharacter[dialogueMs[currentDialogueIndex].charSet[2].charNumber], true);
        }
        if(dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.EventCG)
        {
            SetObjects(eventCGSets[currenteventCG], true);
        }

        //���� ���ϴ� �̰� /�÷��̾�/ ��� �̸��� ������ ������
        if (useCharacter[currentMentCharIndex].Name == "/�÷��̾�/")
        {
            //name���� �ʱ�ȭ
            useCharacter[currentMentCharIndex].Name = playerName;
        }

        //���Ǵ� ĳ���� �̸� �ؽ�Ʈ�� ���� ���� ���Ǵ� �̸����� �ʱ�ȭ
        useCharacter[currentMentCharIndex].nameText.text = useCharacter[currentMentCharIndex].Name;
        //���Ǵ� ���̾�α� �ؽ�Ʈ�� ���� ���� ���Ǵ� ���̾� �ؽ�Ʈ�� �ʱ�ȭ
        useCharacter[currentMentCharIndex].dialogueText.text = dialogueMs[currentDialogueIndex].DialogueData;

        //Ÿ���� ��ɽ���
       // StartCoroutine("OnTyping");
    }

    /// <summary>
    /// ��� ���̾�α� �϶� SetObject
    /// </summary>
    /// <param name="useChar"></param>
    /// <param name="visable"></param>
    private void SetObjects(Character useChar,bool visable)
    {
        if (visable == true)
        {
                useChar.dialRender.gameObject.SetActive(visable);
                useChar.dialogueText.gameObject.SetActive(visable);
                useChar.nameText.gameObject.SetActive(visable);

                useChar.Arrow.gameObject.SetActive(false);
        }
        else if(visable == false)
        {
            useChar.dialRender.gameObject.SetActive(visable);
            useChar.dialogueText.gameObject.SetActive(visable);
            useChar.nameText.gameObject.SetActive(visable);

            useChar.Arrow.gameObject.SetActive(false);
        }

        if (currentDialogueIndex == 0)
        {
            useCharacter[0].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].color = new Color(1, 1, 1, 0);
            useCharacter[0].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].DOFade(1f, 1f);

            if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
            {
                useCharacter[1].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].color = new Color(1, 1, 1, 0);
                useCharacter[1].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].DOFade(1f, 1f);
            }
            if(dialogueMs[currentDialogueIndex].charSet.Length > 2)
            {
                useCharacter[2].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].color = new Color(1, 1, 1, 0);
                useCharacter[2].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].DOFade(1f, 1f);
            }
        }
    }
    private void SetObjects(EventCGSet eventCG,bool visable)
    {
        if(visable == true)
        {
            eventCG.eventRenderer.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].nameText.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].dialogueText.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].dialRender.gameObject.SetActive(visable);
            useCharacter[currentDialogueIndex].Arrow.gameObject.SetActive(false);
        }
        else if(visable == false)
        {
            if (eventCGSets.Length > 0)
            {
eventCG.eventRenderer.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].nameText.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].dialogueText.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].dialRender.gameObject.SetActive(visable);
            useCharacter[currentDialogueIndex].Arrow.gameObject.SetActive(false);
            }
            
        }
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
    public int EmotionName;
}

//����� �̺�Ʈ CG(EventCG(sprite),CGName(string)
[System.Serializable]
public struct EventCGSet
{
    [Header("����� CG������")]
    public SpriteRenderer eventRenderer;
    [Header("���̾�α� �ڽ�")]
    public SpriteRenderer dialogueEvent;
    [Header("���̾� ����- �ؽ�Ʈ")]
    public Text nameText;
    [Header("���̾� �ؽ�Ʈ")]
    public Text dialText;
    [Header("����� �̺�Ʈ CG")]
    public Sprite EventCG;
    [Header("�̺�Ʈ CG ���̾� ����")]
    public SpriteRenderer Arrow;
    [Header("CG�̸�")]
    public int CGName;
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
    public int EventCGSprite;


}
