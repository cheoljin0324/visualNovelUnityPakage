using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovelControler : MonoBehaviour
{
    //비주얼셋 데이터 셋
    VisualSet dataSet;
    //오브젝트 셋
    ObjectSet objectSet;
    //다이얼 컨트롤러(다이얼로그 오브젝트 관리자)
    DialogueControler dialControl;
    //텍스트 관리자
    TextControler textCon;
    //캐릭터 관리자
    CharacetObControler CharCon;
    BackControl backCon;

    EventCGControler EventControler;

    //페이드 중인가?(Y/N) 기본 값은 N
    public bool isFade = false;
    public int isBack = 0;

    void Awake()
    {
        //캐싱 및 Find
        objectSet = GameObject.Find("ObjectSetOb").GetComponent<ObjectSet>();
        dialControl = GameObject.Find("ObjectSetOb").GetComponent<DialogueControler>();
        textCon = GameObject.Find("TextManager").GetComponent<TextControler>();
        backCon = GameObject.Find("BackSprite").GetComponent<BackControl>();
        CharCon = GetComponent<CharacetObControler>();
        dataSet = GetComponent<VisualSet>();
        EventControler = GetComponent<EventCGControler>();
    }


    /// <summary>
    /// 캐릭터 삭제
    /// </summary>
    void DelOB()
    {
        CharCon.CharDel();
    }

    /// <summary>
    /// 다이얼로그 업데이트
    /// </summary>
    /// <returns></returns>
    public bool UpdateDialogue()
    {
        //만약 첫번째 로그일때
        if (dataSet.isFirst == true)
        {
            for(int i = 0; i<backCon.BackOBject.Count; i++)
            {
                if(dataSet.dialogue[dataSet.currentDialogueIndex].backName != i)
                {
                    backCon.OutSetting(i);
                }
            }
            if (dataSet.dialogue[dataSet.currentDialogueIndex].dialogueEvent == DialogueIs.DialogueEven.EventCG)
            {
                EventControler.CreateEvent();
                EventControler.eventSpriteSets();
                EventControler.OnEventCG(dataSet.dialogue[dataSet.currentDialogueIndex].EventCGSprite);
            }

            //초기 배경 전부 생성 및 스프라이트 초기화
            backCon.InSetting(dataSet.dialogue[dataSet.currentDialogueIndex].backName);
            //캐릭터 컨트롤러의 캐릭터 생성 함수를 실행
            CharCon.CreaterCharacetOb();
            //데이터 들의 캐릭터 위치 값만큼
            for(int i = 0; i<dataSet.dialogue[dataSet.currentDialogueIndex].charintPos.Length; i++)
            {
                //캐릭터 위치 초기화
                CharCon.SetPos(i);
            }
            //다음 다이얼로그 실행
            SetNextDialogue();
            //처음 실행된다는 bool 값을 false로 처음 실행되는 다이얼로그가 앞으로는 아님을 쵸기
            dataSet.isFirst = false;
        }
        //아닐경우
        else
        {
            //만약 마우스 버튼을 클릭 했을 경우
            if (Input.GetMouseButtonUp(0))
            {
                //텍스트 컨트롤의 타이핑 중일 경우
                if (textCon.isTyping == true)
                {
                    //타이핑 취소
                    textCon.isTyping = false;
                }
                else
                {
                    //만약 데이터에 다이얼로그 개수가 현재 다이얼로그 인덱스 값보다 클 경우
                    if (dataSet.dialogue.Length > dataSet.currentDialogueIndex + 1)
                    {
                        //다음 로그를 실행
                        SetNextDialogue();
                    }
                    //마지막 다이얼로그일 경우
                    else
                    {
                       //다이얼 컨트롤에 아웃 페이드로 다이얼박스를 페이드
                        dialControl.FadeOutDial(dialControl.DialBox);
                        //삭제
                        DelOB();
                        //텍스트 컨트롤의 다이얼 삭제
                        textCon.DeleteDial();
                        //텍스트 컨트롤의 이름 삭제
                        textCon.DeleteName();
                        
                        //true 값을 돌려주며 다음 코루틴을 실행하게 한다.
                        return true;
                    }

                }


            }
        }
        //false 값을 돌려주며 계속해서 다이얼로그를 진행시킨다.
        return false;
    }


    /// <summary>
    /// 다음 대화 실행
    /// </summary>
    public void SetNextDialogue()
    {
        if (dataSet.isFirst == false)
        {
            EventControler.OffEventCG(dataSet.dialogue[dataSet.currentDialogueIndex].EventCGSprite);
        }
           
        //만약 첫번째 다이얼로그가 아니라면
        if (dataSet.isFirst == false)
        {
            //다이얼로그를 1++
            dataSet.currentDialogueIndex++;
            if(dataSet.isFirst==false&&dataSet.dialogue[dataSet.currentDialogueIndex].dialogueEvent == DialogueIs.DialogueEven.EventCG)
            {
                EventControler.OnEventCG(dataSet.dialogue[dataSet.currentDialogueIndex].EventCGSprite);
            }

            //만약 배경이 다를 경우
            if(dataSet.dialogue[dataSet.currentDialogueIndex - 1].backName!= dataSet.dialogue[dataSet.currentDialogueIndex].backName)
            {
                //배경 생성 및 삭제
                backCon.OutSetting(dataSet.dialogue[dataSet.currentDialogueIndex - 1].backName);
                backCon.InSetting(dataSet.dialogue[dataSet.currentDialogueIndex].backName);
            }
            //이름을 해당 다이얼로그 데이터와 동일하게 바꿔준다.
            textCon.UpdateName(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[dataSet.dialogue[dataSet.currentDialogueIndex].nowMent].charNumber].Name);
            //대화 데이터를 해당 다이얼로그 데이터와 동일하게 바꿔준다.
            textCon.UpdateDial(dataSet.dialogue[dataSet.currentDialogueIndex].DialogueData);
            //만약 데이터 값에 현재 다이얼로그 인덱스가 다이얼로그 길이와 같을 경우
            if (dataSet.currentDialogueIndex == dataSet.dialogue.Length)
            {
                //모든 캐릭터를 삭제
                CharCon.DelFade();
            }
            else
            {
                //아닐 경우 캐릭터 컨트롤에 이모션과 트랜스 를 돌면서 조건에 맞는 오브젝트 들은 바꿔준다.
                CharCon.EmotionFade();
                CharCon.TransPos();
            }
           
        }
        //만약 처음일 경우
        else
        {
            //오브젝트 생성할때 쓰는 페이드 효과 실행
            CharCon.CreateFade();
            //새로운 다이얼 실행
            dialControl.NewDial(objectSet.DialBox);

            //이름 텍스트 생성
            textCon.InstName();
            //다이얼로그 생성
            textCon.InstDial();

            textCon.ReStart();

            //이름 업데이트
            textCon.UpdateName(dataSet.simChar[dataSet.dialogue[dataSet.currentDialogueIndex].charSet[dataSet.dialogue[dataSet.currentDialogueIndex].nowMent].charNumber].Name);
            //다이얼 업데이트
            textCon.UpdateDial(dataSet.dialogue[dataSet.currentDialogueIndex].DialogueData);
        }


    }

}
