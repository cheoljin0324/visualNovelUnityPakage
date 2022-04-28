using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DSFEngine
{
    public class DialogueCLS : MonoSingleton<DialogueCLS>
    {
        [Header("���� ��������Ʈ")]
        [SerializeField]
        public GameObject stainding;

        [Header("ĳ���� ����")]
        [SerializeField]
        public Character[] characters;

        [Header("�̸� �ؽ�Ʈ")]
        [SerializeField]
        public Text nameText;

        [Header("���̾� �ؽ�Ʈ")]
        [SerializeField]
        public Text dialText;

        [Header("�ؽ�Ʈ �ʵ�")]
        [SerializeField]
        public SpriteRenderer textSpriteField;

        [Header("����� �ҽ� ����")]
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


