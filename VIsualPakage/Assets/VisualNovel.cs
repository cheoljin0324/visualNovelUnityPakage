using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Video;


public class VisualNovel : MonoBehaviour
{
    [SerializeField]
    private AudioSource voiceAudio;
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private SpriteRenderer videoObject;
    [SerializeField]
    private Proflie[] proflie;
    [SerializeField]
    private Dialogue[] dialogues;
    [SerializeField]
    private Sprite[] backGroundClip;
    [SerializeField]
    private SpriteRenderer backSpriteRenderer;

    private string name = "����";
    private bool isFirst = true;
    private bool isAuto = true;
    private int currentDialogueIndex = -1;
    private int currentCharIndex = 0;
    private int currentBack = 0;
    private float typingspd = 0.03f;
    private bool isTyping = false;
    private bool isAnimation = false;
    private bool isDialStart = true;

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        for(int i = 0; i<proflie.Length; ++i)
        {
            SetActiveObjects(proflie[i], false);
        }

    }

    public bool UpdateDialog()
    {
       
        if(isFirst == true)
        {
            Setup();
            if (isAuto) SetNextDialog();
            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            voiceAudio.Stop();
            if (currentDialogueIndex+1 > dialogues.Length)
            {
                if (currentDialogueIndex <= dialogues.Length&&proflie[dialogues[currentDialogueIndex].CharacterNum].CharacterSprite.sprite != proflie[dialogues[currentDialogueIndex + 1].CharacterNum].CharacterSprite.sprite)
            {
                isAnimation = true;
            }

            }

            if (isTyping == true)
            {
                isTyping = false;

                StopCoroutine("Ontyping");
                proflie[currentCharIndex].dialgoueText.text = dialogues[currentDialogueIndex].DialogueComData;
                proflie[currentCharIndex].Arrow.gameObject.SetActive(true);
            }

            if (dialogues.Length > currentDialogueIndex + 1)
            {
                SetNextDialog();
            }
            else
            {
                for(int i = 0; i<proflie.Length; ++i)
                {
                    SetActiveObjects(proflie[i], false);
                   
                }
                return true;
            }
        }
        return false;
    }

    public void SetNextDialog()
    {  

        SetActiveObjects(proflie[currentCharIndex], false);

        currentDialogueIndex++;
        dialogues[currentDialogueIndex].DialogueComData = dialogues[currentDialogueIndex].DialogueComData.Replace("/�÷��̾�/", name);
        currentCharIndex = dialogues[currentDialogueIndex].CharacterNum;

        proflie[currentCharIndex].CharacterSprite.sprite = proflie[currentCharIndex].CharacterEmotion[dialogues[currentDialogueIndex].Emotion];
       
        SetActiveObjects(proflie[currentCharIndex], true);

        if (proflie[currentCharIndex].name=="/�÷��̾�/")
        {
            proflie[currentCharIndex].name = name;
        }
        proflie[currentCharIndex].nameText.text = proflie[currentCharIndex].name;
        proflie[currentCharIndex].dialgoueText.text = dialogues[currentDialogueIndex].DialogueComData;
        StartCoroutine("Ontyping");
    }

    private void SetActiveObjects(Proflie profiles , bool visable)
    {

        if (visable == true)
        {
            if (dialogues[currentDialogueIndex].audioClip != null)
            {
                voiceAudio.clip = dialogues[currentDialogueIndex + 1].audioClip;
                voiceAudio.Play();
            }

            if(dialogues[currentDialogueIndex].onVideo == true)
            {
                videoObject.gameObject.SetActive(true);
                if(dialogues[currentDialogueIndex].onVideo == false)
                {
                    videoPlayer.clip = dialogues[currentDialogueIndex].useVideo;
                    videoPlayer.Play();
                }
                else if(dialogues[currentDialogueIndex-1].useVideo != dialogues[currentDialogueIndex].useVideo)
                {
                    videoPlayer.clip = dialogues[currentDialogueIndex].useVideo;
                    videoPlayer.Play();
                }
            }

            if (dialogues[currentDialogueIndex].onVideo == false)
            {
                videoPlayer.Stop();
                videoObject.gameObject.SetActive(false);
                
            }

            if (dialogues[currentDialogueIndex].angryEvent == true)
            {
                StartCoroutine(Shake());
            }
            if (currentDialogueIndex == 0)
            {
                profiles.CharacterSprite.color = profiles.CharacterSprite.color * new Color(1, 1, 1, 0);
                profiles.CharacterSprite.DOFade(1f, 1f);
            }
            else if (profiles.CharacterSprite.sprite != proflie[dialogues[currentDialogueIndex-1].CharacterNum].CharacterSprite.sprite)
            {
                profiles.CharacterSprite.color = profiles.CharacterSprite.color * new Color(1, 1, 1, 0);
                profiles.CharacterSprite.DOFade(1f, 1f);
            }

            if (isDialStart == true)
            {
                currentBack = dialogues[currentDialogueIndex].backGround;
                backSpriteRenderer.sprite = backGroundClip[currentBack];

                isDialStart = false;
            }

            if (currentBack != dialogues[currentDialogueIndex].backGround)
            {
                currentBack = dialogues[currentDialogueIndex].backGround;
                backSpriteRenderer.sprite = backGroundClip[currentBack];
            }

            StartCoroutine(FalseOb(profiles, visable));
        }


        else if(visable == false)
        {
            if (isAnimation == true)
            {
                profiles.CharacterSprite.DOFade(0f, 0.2f);
            }
            StartCoroutine(FalseOb(profiles, visable));

        }

        profiles.dialoguePanel.gameObject.SetActive(visable);
        profiles.nameText.gameObject.SetActive(visable);
        profiles.dialgoueText.gameObject.SetActive(visable);

        profiles.Arrow.gameObject.SetActive(false);
    }

    IEnumerator Ontyping()
    {
        int index = 0;

        isTyping = true;

        WaitForSeconds waitForSeconds = new WaitForSeconds(typingspd);
        while (index < dialogues[currentDialogueIndex].DialogueComData.Length)
        {
            proflie[currentCharIndex].dialgoueText.text = dialogues[currentDialogueIndex].DialogueComData.Substring(0, index+1);

            index++;

            yield return waitForSeconds;
        }
        isTyping = false;
        proflie[currentCharIndex].Arrow.gameObject.SetActive(true);
    }

    IEnumerator FalseOb(Proflie profiles,bool visable)
    {
        if(visable == true)
        {
            profiles.CharacterSprite.gameObject.SetActive(visable);
        }
        else if(visable == false)
        {
            if (isAnimation == true)
            {
                yield return new WaitForSeconds(0.4f);
                isAnimation = false;
                profiles.CharacterSprite.gameObject.SetActive(visable);
            }
            else
            {
                profiles.CharacterSprite.gameObject.SetActive(visable);
            }
            }
        }

    IEnumerator Shake()
    {
        for(int i = 0; i<10; i++)
        {
            proflie[currentCharIndex].CharacterSprite.transform.DOMove(new Vector3(proflie[currentCharIndex].CharacterSprite.transform.position.x+0.1f, proflie[currentCharIndex].CharacterSprite.transform.position.y, 0f), 0.05f, false);
            yield return new WaitForSeconds(0.05f);
            proflie[currentCharIndex].CharacterSprite.transform.DOMove(new Vector3(proflie[currentCharIndex].CharacterSprite.transform.position.x-0.1f, proflie[currentCharIndex].CharacterSprite.transform.position.y, 0f), 0.05f, false);
            yield return new WaitForSeconds(0.05f);
        }
    }
       
    }
 

   


[System.Serializable]
public struct Proflie
{
    [Header("�̸�")]
    public string name;

    [Header("ĳ���� ���� �̹���")]
    public SpriteRenderer CharacterSprite;
    [Header("ĳ���� ���� ���")]
    public Sprite[] CharacterEmotion;

    [Header("��ȭâ �̹���")]
    public Image dialoguePanel;
    [Header("�÷��̾� �̸� ��� �ؽ�Ʈ")]
    public Text nameText;
    [Header("�÷��̾� ��ȭ ��� �ؽ�Ʈ")]
    public Text dialgoueText;

    [Header("������Ʈ�� �������� �˷��ִ� �̹���")]
    public Image Arrow;

}

[System.Serializable]
public struct Dialogue
{
    [Header("��� �� ĳ���� �ѹ���")]
    public int CharacterNum;

    [Header("���� ��뿩��")]
    public bool onVideo;

    [Header("����� ����")]
    public VideoClip useVideo;

    [Header("����")]
    public AudioClip audioClip;

    [Header("�ش� ĳ���� ���� ������ȣ")]
    public int Emotion;

    [Header("���")]
    public int backGround;

    [Header("ȭ�� ȿ��")]
    public bool angryEvent;

    [Header("��ȭ")]
    [TextArea(3, 5)]
    public string DialogueComData;
}



