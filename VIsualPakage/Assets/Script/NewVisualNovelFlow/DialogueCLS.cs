using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DSFEngine
{
    public class DialogueCLS : MonoSingleton<DialogueCLS>
    {
        [Header("생성 스프라이트")]
        [SerializeField]
        public GameObject stainding;

        [Header("캐릭터 정리")]
        [SerializeField]
        public Character[] characters;

        [Header("이름 텍스트")]
        [SerializeField]
        public Text nameText;

        [Header("다이얼 텍스트")]
        [SerializeField]
        public Text dialText;

        [Header("텍스트 필드")]
        [SerializeField]
        public SpriteRenderer textSpriteField;

        [Header("오디오 소스 정리")]
        [SerializeField]
        public AudioClip[] audioBox;
    }

    [System.Serializable]
    public struct Character
    {
        public string charName;
        public string char_Id;
        public Sprite MainChar;
        public Sprite[] CharEmotion;
    }
}


