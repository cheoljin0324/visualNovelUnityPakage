using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogueSet : MonoBehaviour
{
    //�ؽ�Ʈ ������Ʈ ���� ����
    TextObject texting;

    //�ش� ������ �־��ֱ� ���� ���� ����
    public GameObject DialTextN;

    private void Awake()
    {
        //ĳ��
        texting = GetComponent<TextObject>();

    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void InstName()
    {
        //���̾� �ؽ�Ʈ�� texting�̶�� �̸��� �ؽ�Ʈ�� ����
        DialTextN = Instantiate(texting.DialText);
        //ĵ������ ���
        DialTextN.transform.parent = GameObject.Find("Canvas").transform;
    }

    public void NameSet(string Name)
    {
        //ĳ��
        DialTextN.GetComponent<Text>().text = Name;
    }


}
