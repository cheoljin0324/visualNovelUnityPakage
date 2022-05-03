using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;

public class VisualNovelReReady : MonoBehaviour
{
    //사용 될 이벤트 CG
    public EventCGSet[] eventCGSets;
    //사용 될 캐릭터
    public Character[] useCharacter;
    //사용될 배경
    public BackScreen[] backScreen;
    //사용될 다이얼로그 속성
    public DialogueM[] dialogueMs;

    //유저 이름
    private string playerName = "";
    //다이얼로그의 첫 스타트 부근인가?
    private bool isFirst = true;
    //자동으로 진행이 되는가?
    private bool isAuto = true;
    public bool autoFlow;
    //현재 다이얼로그 진행도
    private int currentDialogueIndex = -1;
    //캐릭터 정수(최대 3명)
    private int[] currentCharIndex = new int[3];
    //현재 말하고 있는 캐릭터 정수
    private int currentMentCharIndex = 0;
    //배경 정수 아이디
    private int currentBackNum;
    //타이핑 효과에서 쓰일 타이핑 속도
    private float typingSpd = 0.03f;
    //타이핑이 현재 진행중인가?
    private bool isTyping = false;

    private bool fast;

    private float fadeTime = 0.5f;
    //현재 사용중인 이벤트CG
    private int currenteventCG;
    private bool isFade = false;

    float timer = 0f;
    float waitTime = 1.2f;


    private void Awake()
    {
        currentBackNum = dialogueMs[currentDialogueIndex + 1].backName;

        //초기 값으로 정해줄 사용되는 캐릭터 정수 초기화
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
        //초기화
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
    /// 초기화 함수
    /// </summary>
    private void SetScreen()
    {
        //캐릭터에 들어있는 캐릭터 만큼
        for(int i = 0; i<useCharacter.Length; ++i)
        {
            //캐릭터 있는 것들을 진행을 위해 우선 꺼준다.
            SetObjects(useCharacter[i], false);
   
        }
        //CG들어있는 만큼
        if (eventCGSets.Length > 0)
        {
            for (int i = 0; i < eventCGSets.Length; i++)
            {
                //CG오브젝트 전부 꺼내준다.
                SetObjects(eventCGSets[i], false);
            }
        }
        
    }

    /// <summary>
    /// 현재 쓰이는 다이얼로그를 업데이트
    /// </summary>
    public bool UpdateDialogue()
    {
        //현재 첫 번째 대화창인가?
        if(isFirst == true)
        {
            //초기화
            SetScreen();
            //자동 시작일 경우 자동으로 다음 대화 실행
            if (isAuto) SetNextDialogue();
            //이 이후로 처음은 아니기에 처음 값을 거짓으로 변경
            isFirst = false;
        }

        //만약 마우스 버튼(0)을 누를 경우
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
                //만약 타이핑 도중이었다면
                if (isTyping == true)
                {
                    //타이핑을 종료
                    isTyping = false;
                    //타이핑 하고 있던 코루틴을 종료
                    StopCoroutine("Ontyping");
                    //타이핑 하던 텍스트를 순간적으로 대화 완성본으로 초기화
                    useCharacter[currentMentCharIndex].dialogueText.text = dialogueMs[currentDialogueIndex].DialogueData;
                    //끝났다는 화살표를 표기
                    useCharacter[currentMentCharIndex].Arrow.gameObject.SetActive(true);
                }
                if (isFade == true)
                {
                    useCharacter[0].spriteRenderers[0].color = new Color(1, 1, 1, 0);
                    useCharacter[0].spriteRenderers[1].color = new Color(1, 1, 1, 0);
                    useCharacter[0].spriteRenderers[2].color = new Color(1, 1, 1, 0);

                    isFade = false;
                }

                //만약 이게 마지막 대화창이 아닐 경우
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

                //만약 이게 마지막 대화창일 경우
                else
                {
                    //모든 캐릭터에 있는 수치를
                    for (int i = 0; i < useCharacter.Length; ++i)
                    {
                        //해제
                        SetObjects(useCharacter[i], false);
                    }

                    if (eventCGSets.Length > 0)
                    {
                        for (int i = 0; i < eventCGSets.Length; i++)
                        {
                            SetObjects(eventCGSets[i], false);
                        }
                    }

                    //트루를 반환하면서 다음 함수 진행되게 함
                    return true;
                }

            }
        }
        //아닐 경우는 항상 false로 해당 함수에 머물게 함
        return false;
    }

    public void Update()
    {
        timer += Time.deltaTime;
    }

    /// <summary>
    /// 다음 대화 진행
    /// </summary>
    public void SetNextDialogue()
    {
        
        currentDialogueIndex++;

        //다음 대화창에 있는 값들을 전부 적용
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
        

        //만약 다음 대화 내용 중 /플레이어/ 라는 키워드가 있을때 맨 위에 선언해준 이름으로 변경
        dialogueMs[currentDialogueIndex].DialogueData = dialogueMs[currentDialogueIndex].DialogueData.Replace("/플레이어/", playerName);
        //현재 대화 하고 있는 인물의 값을 적용
        currentMentCharIndex = dialogueMs[currentDialogueIndex].nowMent;

        if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.NormalDial)
        {
            //사용되는 캐릭터에 있는 스프라이트 렌더러를 적용
            useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].sprite = useCharacter[currentCharIndex[0]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[0].Emotion].charSprite;
            if (dialogueMs[currentDialogueIndex].zoom == true)
            {
                useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale = new UnityEngine.Vector3(useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.x * 2, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.y * 2, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.localScale.z);
                useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.position = new UnityEngine.Vector3(useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.position.x+1, useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].transform.position.y - 6, 0);
            }
            useCharacter[currentCharIndex[0]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[0]].gameObject.SetActive(true);
            StartCoroutine(FadeIn(dialogueMs[currentDialogueIndex].charintPos[0]));
            //만약 사용되는 캐릭터가 1명보다 많을때
            if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
            {
                //두번째 캐릭터 적용
                useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].sprite = useCharacter[currentCharIndex[1]].charSpriteSet[dialogueMs[currentDialogueIndex].charSet[1].Emotion].charSprite;
                if (dialogueMs[currentDialogueIndex].zoom == true)
                {
                    useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].transform.localScale = new UnityEngine.Vector3(useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].transform.localScale.x * 2, useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].transform.localScale.y * 2, useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].transform.localScale.z);
                }
                useCharacter[currentCharIndex[1]].spriteRenderers[dialogueMs[currentDialogueIndex].charintPos[1]].gameObject.SetActive(true);
                StartCoroutine(FadeIn(dialogueMs[currentDialogueIndex].charintPos[1]));
            }
            //3명 보다 많을때
            if (dialogueMs[currentDialogueIndex].charSet.Length > 2)
            {
                //3명까지 적용
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
        

        //오브젝트를 전부 켜준다.
        if (dialogueMs[currentDialogueIndex].dialogueEvent == DialogueM.DialogueEvent.NormalDial)
        {
            SetObjects(useCharacter[dialogueMs[currentDialogueIndex].charSet[0].charNumber], true);
            //만약 1명보다 많으면
            if (dialogueMs[currentDialogueIndex].charSet.Length > 1)
            {
                SetObjects(useCharacter[dialogueMs[currentDialogueIndex].charSet[1].charNumber], true);
            }
            //만약 2명보다 많으면
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

        //만약 말하는 이가 /플레이어/ 라는 이름을 가지고 있을때
        if (useCharacter[currentMentCharIndex].Name == "/플레이어/")
        {
            //name으로 초기화
            useCharacter[currentMentCharIndex].Name = playerName;
        }

        //사용되는 캐릭터 이름 텍스트를 지금 현재 사용되는 이름으로 초기화
        useCharacter[currentMentCharIndex].nameText.text = useCharacter[currentMentCharIndex].Name;
        //사용되는 다이얼로그 텍스트를 지금 현재 사용되는 다이얼 텍스트로 초기화
        useCharacter[currentMentCharIndex].dialogueText.text = dialogueMs[currentDialogueIndex].DialogueData;

        //타이핑 기능실행
        StartCoroutine("Ontyping");
    }

    /// <summary>
    /// 노멀 다이얼로그 일때 SetObject
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



//사용할 캐릭터 스프라이트를 정리해놓은 구조체(charSprite(sprite),stringEmotionName(string))
[System.Serializable]
public struct CharSpriteSet
{
    [Header("캐릭터 스프라이트 목록")]
    public Sprite charSprite;
    [Header("캐릭터 해당 스프라이트 이름")]
    public int EmotionName;
}

//사용할 이벤트 CG(EventCG(sprite),CGName(string)
[System.Serializable]
public struct EventCGSet
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

//배경 정리(backSprite(Sprite), backName(string))
[System.Serializable]
public struct BackScreen
{
    [Header("사용할 배경")]
    public Sprite backSprite;

    [Header("배경 렌더러")]
    public SpriteRenderer spriteRenderer;

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
    [Header("사용 감정(정수)")]
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
    [Header("줌 인")]
    public bool zoom;

    [Header("애니매이션")]
    public bool oneFade;
    public bool twoFade;
    public bool threeFade;

    [Header("화난 효과")]
    public bool isAngry;
    [Header("사용할 배경")]
    public int backName;

    [Header("사용할 비디오")]
    public VideoClip useVideo;

    [Header("더빙")]
    public AudioClip audioClip;

    [Header("사용할 이벤트 CG")]
    public int EventCGSprite;


}
