using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialDataSet : MonoBehaviour
{
    //텍스트 다이얼로그를 적용 시켜주는 변수
    TextDialogueSet textDial;
    //텍스트 컨트롤러를 캐싱해주기 위한 변수
    TextControler textCon;
    //타이핑 스피드
    public float TypingSpd = 0.05f;

    private void Awake()
    {
        //텍스트 다이얼로그 셋을 캐싱
        textDial = GetComponent<TextDialogueSet>();
        //텍스트 컨트롤러를 캐싱
        textCon = GetComponent<TextControler>();

    }

    /// <summary>
    /// 다이얼 데이터를 적용 시켜주는 함수
    /// </summary>
    /// <param name="Dial"></param>
    public void DialData(string Dial)
    {
        //타이핑 스타트 코루틴 실행
        StartCoroutine("Typing", Dial);
    }

    IEnumerator Typing(string Dial)
    {
        //타이핑 갯수를 카운트할 인덱스 변수 생성
        int index = 0;

        //지금 타이핑 중이라는 bool 값을 true로 변경 지금 현재 타이핑 중이라는 플래그를 세운다
        textCon.isTyping = true;

        //index가 다이얼 보다 많아질때 까지
        while(index < Dial.Length+1)
        {
            //텍스트 다이얼에 오브젝트 DialTextN의 오브젝트를 나눈다.
            textDial.DialTextN.GetComponent<Text>().text = Dial.Substring(0, index);
            //인덱스 +=1
            index++;

            //텍스트 컨트롤러에 isTyping이 false 로 바꿔준다.
            if (textCon.isTyping == false)
            {
                //텍스트 다이얼의 이름 텍스트를 초기화
                textDial.DialTextN.GetComponent<Text>().text = Dial;
                //인덱스는 넣어줘야하는 문자열 데이터 길이가 된다.
                index = Dial.Length;
            }
            //타이핑 스피드 만큼 대기
            yield return new WaitForSeconds(TypingSpd);
        }
        //텍스트 컨트롤러의 isTyping을 false 로 초기화
        textCon.isTyping = false;
    }
}
