using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//���Ǵ� ������ ����ü ����
[System.Serializable]
public struct DialogueIs
{
    public enum DialogueEven { NormalDial, EventCG, VideoCG }

    [Header("��ȭ ����")]
    public DialogueEven dialogueEvent;

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

    [Header("ȭ�� ȿ��")]
    public bool isAngry;
    [Header("����� ���")]
    public int backName;

    [Header("����")]
    public AudioClip audioClip;

    [Header("����� �̺�Ʈ CG")]
    public int EventCGSprite;


}

[System.Serializable]
public struct EventSet
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



[System.Serializable]
public struct SimCharacter
{
    [Header("�̸�")]
    public string Name;
    [Header("ĳ���� ��������Ʈ ���")]
    public Sprite[] charSprite;
}
