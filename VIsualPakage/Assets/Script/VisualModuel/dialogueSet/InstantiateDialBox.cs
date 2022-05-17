using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDialBox : MonoBehaviour
{
    //다이얼 박스를 생성해서 변형 시킬 오브젝트를 변수형태로 변환
    [HideInInspector]
    public GameObject DialBox;
    //페이드 효과를 위한 페이드 다이얼 박스 캐싱
    FadeDialBox fade;

    public void Awake()
    {
        //페이드 캐싱
        fade = GetComponent<FadeDialBox>();
    }

    public void DialogueBoxSet(GameObject dialogueBox)
    {
        //다이얼 박스를 생성
        DialBox = Instantiate(dialogueBox);
        //컬러값을 투명하게 초기화
        DialBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);//이 부분은 나중에 (1,1,1,0)으로 꼭 바꿀 것
        //페이드
        fade.InstDialFade(DialBox);
    }

}
