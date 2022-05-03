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
    public bool autoFlow;
    //���� ���̾�α� ���൵
    private int currentDialogueIndex = -1;
    //ĳ���� ����(�ִ� 3��)
    private int[] currentCharIndex = new int[3];
    //���� ���ϰ� �ִ� ĳ���� ����
    private int currentMentCharIndex = 0;
    //��� ���� ���̵�
    private int currentBackNum;
    //Ÿ���� ȿ������ ���� Ÿ���� �ӵ�
    private float typingSpd = 0.03f;
    //Ÿ������ ���� �������ΰ�?
    private bool isTyping = false;

    private bool fast;

    private float fadeTime = 0.5f;
    //���� ������� �̺�ƮCG
    private int currenteventCG;
    private bool isFade = false;

    float timer = 0f;
    float waitTime = 1.2f;


    private void Awake()
    {
        currentBackNum = dialogueMs[currentDialogueIndex + 1].backName;

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

    private void Start()
    {
        FastMode();
    }

    void FastMode()
    {
        waitTime = waitTime / 10;
        typingSpd /= 15;

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
            for (int i = 0; i < eventCGSets.Length; i++)
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
        if (Input.GetMouseButtonDown(0)||autoFlow == true)
        {
            if (timer > waitTime)
            {
                timer = 0;
                if (dialogueMs[currentDialogueIndex].zoom == true && dialogueMs[currentDialogueIndex + 1].zoom == false)
                {
                    useCharacter[0].spriteRenderers[1].transform.localScale = new UnityEngine.Vector3(useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.x / 2, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.y / 2, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.z);
                    useCharacter[0].spriteRenderers[1].transform.position = new UnityEngine.Vector3(useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.position.x - 1, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.position.y + 6, 0);
                }
                //���� Ÿ���� �����̾��ٸ�
                if (isTyping == true)
                {
                    //Ÿ������ ����
                    isTyping = false;
                    //Ÿ���� �ϰ� �ִ� �ڷ�ƾ�� ����
                    StopCoroutine("Ontyping");
                    //Ÿ���� �ϴ� �ؽ�Ʈ�� ���������� ��ȭ �ϼ������� �ʱ�ȭ
                    useCharacter[currentMentCharIndex].dialogueText.text = dialogueMs[currentDialogueIndex].DialogueData;
                    //�����ٴ� ȭ��ǥ�� ǥ��
                    useCharacter[currentMentCharIndex].Arrow.gameObject.SetActive(true);
                }
                if (isFade == true)
                {
                    useCharacter[0].spriteRenderers[0].color = new Color(1, 1, 1, 0);
                    useCharacter[0].spriteRenderers[1].color = new Color(1, 1, 1, 0);
                    useCharacter[0].spriteRenderers[2].color = new Color(1, 1, 1, 0);

                    isFade = false;
                }

                //���� �̰� ������ ��ȭâ�� �ƴ� ���
                if (dialogueMs.Length > currentDialogueIndex + 1)
                {
                    if (dialogueMs[currentDialogueIndex].oneFade == true)
                    {
                        isFade = true;
                        StartCoroutine(FadeOut(0));
                    }
                    if (dialogueMs[currentDialogueIndex].twoFade == true)
                    {
                        isFade = true;
                        StartCoroutine(FadeOut(1));

                    }
                    else
                    {
                        useCharacter[0].spriteRenderers[1].color = new Color(1, 1, 1, 0);
                    }
                    if (dialogueMs[currentDialogueIndex].threeFade == true)
                    {
                        isFade = true;
                        StartCoroutine(FadeOut(2));
                    }
                    else
                    {
                        useCharacter[0].spriteRenderers[2].color = new Color(1, 1, 1, 0);
                    }
                    StartCoroutine(FalseOb(false));
                    if (dialogueMs[currentDialogueIndex].oneFade == true || dialogueMs[currentDialogueIndex].twoFade == true || dialogueMs[currentDialogueIndex].threeFade == true)
                    {
                        Invoke("SetNextDialogue", 1.5f);
                    }
                    else
                    {
                        SetNextDialogue();
                    }

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
        }
        //�ƴ� ���� �׻� false�� �ش� �Լ��� �ӹ��� ��
        return false;
    }

    public void Update()
    {
        timer += Time.deltaTime;
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
        currentBackNum = dialogueMs[currentDialogueIndex].backName;

        if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.EventCG)
        {
            currenteventCG = dialogueMs[currentDialogueIndex].EventCGSprite;
        }
        

        //���� ���� ��ȭ ���� �� /�÷��̾�/ ��� Ű���尡 ������ �� ���� �������� �̸����� ����
        dialogueMs[currentDialogueIndex].DialogueData = dialogueMs[currentDialogueIndex].DialogueData.Replace("/�÷��̾�/", playerName);
        //���� ��ȭ �ϰ� �ִ� �ι��� ���� ����
        currentMentCharIndex = dialogueMs[currentDialogueIndex].nowMent;

        if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.NormalDial)
        {
            //���Ǵ� ĳ���Ϳ� �ִ� ��������Ʈ �������� ����
            useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].sprite = useCharacter[currentCharIndex[0]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[0].Emotion].charSprite;
            if (dialogueMs[currentDialogueIndex].zoom == true)
            {
                useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale = new UnityEngine.Vector3(useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.x * 2, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.y * 2, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.z);
                useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.position = new UnityEngine.Vector3(useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.position.x+1, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.position.y - 6, 0);
            }
            useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].gameObject.SetActive(true);
            StartCoroutine(FadeIn(dialogueMs[currentDialogueIndex].charintPos[0]));
            //���� ���Ǵ� ĳ���Ͱ� 1���� ������
            if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
            {
                //�ι�° ĳ���� ����
                useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].sprite = useCharacter[currentCharIndex[1]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[1].Emotion].charSprite;
                if (dialogueMs[currentDialogueIndex].zoom == true)
                {
                    useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].transform.localScale = new UnityEngine.Vector3(useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].transform.localScale.x * 2, useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].transform.localScale.y * 2, useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].transform.localScale.z);
                }
                useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].gameObject.SetActive(true);
                StartCoroutine(FadeIn(dialogueMs[currentDialogueIndex].charintPos[1]));
            }
            //3�� ���� ������
            if (dialogueMs[currentDialogueIndex].charSet.Length > 2)
            {
                //3����� ����
                useCharacter[currentCharIndex[2]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].sprite = useCharacter[currentCharIndex[2]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[2].Emotion].charSprite;
                if (dialogueMs[currentDialogueIndex].zoom == true)
                {
                    useCharacter[currentCharIndex[2]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].transform.localScale = new UnityEngine.Vector3(useCharacter[currentCharIndex[2]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].transform.localScale.x * 2, useCharacter[currentCharIndex[2]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].transform.localScale.y * 2, useCharacter[currentCharIndex[2]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].transform.localScale.z);
                }
                useCharacter[currentCharIndex[2]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].gameObject.SetActive(true);
                StartCoroutine(FadeIn(dialogueMs[currentDialogueIndex].charintPos[2]));
            }
            backScreen[currentBackNum].spriteRenderer.sprite = backScreen[currentBackNum].backSprite;
        }
        if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.EventCG)
        {
            eventCGSets[currenteventCG].eventRenderer.sprite = eventCGSets[currenteventCG].EventCG;
        }
        

        //������Ʈ�� ���� ���ش�.
        if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.NormalDial)
        {
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
            if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.EventCG)
            {
                SetObjects(eventCGSets[currenteventCG], true);
            }
        }
        else if(dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.EventCG)
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
        StartCoroutine("Ontyping");
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
            useChar.spriteRenderers[0].gameObject.SetActive(visable);

            useChar.Arrow.gameObject.SetActive(false);


            if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
            {
                useChar.spriteRenderers[1].gameObject.SetActive(visable);
            }
            if (dialogueMs[currentDialogueIndex].charSet.Length > 2)
            {
                useChar.spriteRenderers[2].gameObject.SetActive(visable);
            }

        }
        else if(visable == false)
        {
            useChar.dialRender.gameObject.SetActive(visable);
            useChar.dialogueText.gameObject.SetActive(visable);
            useChar.nameText.gameObject.SetActive(visable);

            useChar.Arrow.gameObject.SetActive(false);

            useChar.spriteRenderers[0].gameObject.SetActive(visable);
            useChar.spriteRenderers[1].gameObject.SetActive(visable);
            useChar.spriteRenderers[2].gameObject.SetActive(visable);

            useChar.spriteRenderers[0].color = new Color(1, 1, 1, 0);
            useChar.spriteRenderers[1].color = new Color(1, 1, 1, 0);
            useChar.spriteRenderers[2].color = new Color(1, 1, 1, 0);
        }

        if (currentDialogueIndex == 0)
        {
            useCharacter[0].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].color = new Color(1, 1, 1, 0);
            if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.NormalDial)
            {
                useCharacter[0].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].DOFade(1f, 1f);
            }


            if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
            {
                useCharacter[1].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].color = new Color(1, 1, 1, 0);
                if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.NormalDial)
                {
                    if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
                    {
                        useCharacter[0].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].DOFade(1f, 1f);
                    }

                }

            }
            if (dialogueMs[currentDialogueIndex].charSet.Length > 2)
            {
                useCharacter[2].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].color = new Color(1, 1, 1, 0);
                if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.NormalDial)
                {
                    if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
                    {
                        useCharacter[0].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[2]].DOFade(1f, 1f);
                    }
                }

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

            FalseOb(visable);
        }
        else if(visable == false)
        {
            if (eventCGSets.Length > 0)
            {
            eventCG.eventRenderer.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].nameText.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].dialogueText.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].dialRender.gameObject.SetActive(visable);
            useCharacter[currentMentCharIndex].Arrow.gameObject.SetActive(false);

            FalseOb(visable);
            }
            
        }
    }

    IEnumerator Ontyping()
    {
        int index = 0;

        isTyping = true;

        WaitForSeconds waitForSeconds = new WaitForSeconds(typingSpd);
        while (index < dialogueMs[currentDialogueIndex].DialogueData.Length)
        {
            useCharacter[currentMentCharIndex].dialogueText.text = dialogueMs[currentDialogueIndex].DialogueData.Substring(0, index + 1);
            index++;

            yield return waitForSeconds;
        }
        isTyping = false;
        useCharacter[currentMentCharIndex].Arrow.gameObject.SetActive(true);
    }

    IEnumerator FadeIn(int val)
    {
        useCharacter[0].spriteRenderers[val].DOFade(1f, fadeTime);


        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator FadeOut(int val)
    {
        isFade = true;
        useCharacter[0].spriteRenderers[val].DOFade(0f, fadeTime);

        yield return new WaitForSeconds(0.5f);
        isFade = false;
    }

    IEnumerator FalseOb(bool visable)
    {

        yield return new WaitForSeconds(0.5f);
        if (visable == true)
        {
            useCharacter[0].spriteRenderers[0].gameObject.SetActive(true);
            useCharacter[0].spriteRenderers[1].gameObject.SetActive(true);
            useCharacter[0].spriteRenderers[2].gameObject.SetActive(true);
        }
        else if (visable == false)
        {
           
            useCharacter[0].spriteRenderers[0].gameObject.SetActive(true);
            useCharacter[0].spriteRenderers[1].gameObject.SetActive(true);
            useCharacter[0].spriteRenderers[2].gameObject.SetActive(true);
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

    [Header("��� ������")]
    public SpriteRenderer spriteRenderer;

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
    [Header("�� ��")]
    public bool zoom;

    [Header("�ִϸ��̼�")]
    public bool oneFade;
    public bool twoFade;
    public bool threeFade;

    [Header("ȭ�� ȿ��")]
    public bool isAngry;
    [Header("����� ���")]
    public int backName;

    [Header("����� ����")]
    public VideoClip useVideo;

    [Header("����")]
    public AudioClip audioClip;

    [Header("����� �̺�Ʈ CG")]
    public int EventCGSprite;


}
