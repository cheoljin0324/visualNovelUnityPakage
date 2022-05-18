using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstCharacterOb : MonoBehaviour
{
    //charData는 Getchar 형태로 캐싱 준비 선언
    charData Getchar;

    private void Awake()
    {
        //Getchar를 캐싱
        Getchar = GetComponent<charData>();
    }

    /// <summary>
    /// Length값을 받고 이중 리스트 GameObject로 선언
    /// </summary>
    /// <param name="Length"></param>
    /// <param name="Char"></param>
    public void InstantiateObject(int Length, List<List<GameObject>> Char)
    {
        //게임오브젝트 리스트 값으로 감정
        List<GameObject> Emotion = new List<GameObject>();

        //i는 Length값 만큼 반복
        for(int i = 0; i<Length; i++)
        {
            //GameObject 는 NChar는 Instantiate GetChar의 생성할 오브젝트 값을 생성
            GameObject NChar= Instantiate(Getchar.Inst);
            //이모션 리스트를 생성
            Emotion.Add(NChar);
        }
        //캐릭터를 생성
        Char.Add(Emotion);
    }

}
