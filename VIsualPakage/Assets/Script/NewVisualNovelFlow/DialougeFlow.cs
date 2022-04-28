using System.Collections;
using System.Collections.Generic;
using DSFEngine;
using UnityEngine;


//Say("대화 내용, 사용할 캐릭터 아이디, 해당 캐릭터의 표정(정수), 사용되는 배경(정수), 캐릭터의 위치(정수-0왼쪽,1가운데,2오른쪽))"
//Say("대화 내용, 첫번째 캐릭터 아이디, 두번째 캐릭터 아이디, 첫 번째 캐릭터 정수(정수), 두 번째 캐릭터 정수(정수), 배경(정수), 말하는 캐릭터(첫 번째(1),두 번째(2)), 첫 번째 캐릭터 위치, 두 번째 캐릭터 위치)

public class DialougeFlow : ScritControler
{

    [SerializeField]
    SayScript Say;

    [SerializeField]
    Effect Effect;

    [SerializeField]
    DialogueCLS charData;

    public void Start()
    {
        Say.Say("안녕");
    }


    }


