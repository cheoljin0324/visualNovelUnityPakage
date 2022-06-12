using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstCharacterOb : MonoBehaviour
{
    //charData�� Getchar ���·� ĳ�� �غ� ����
    charData Getchar;

    private void Awake()
    {
        //Getchar�� ĳ��
        Getchar = GetComponent<charData>();
    }

    /// <summary>
    /// Length���� �ް� ���� ����Ʈ GameObject�� ����
    /// </summary>
    /// <param name="Length"></param>
    /// <param name="Char"></param>
    public void InstantiateObject(int Length, List<List<GameObject>> Char)
    {
        //���ӿ�����Ʈ ����Ʈ ������ ����
        List<GameObject> Emotion = new List<GameObject>();

        //i�� Length�� ��ŭ �ݺ�
        for(int i = 0; i<Length; i++)
        {
            //GameObject �� NChar�� Instantiate GetChar�� ������ ������Ʈ ���� ����
            GameObject NChar= Instantiate(Getchar.Inst);
            //�̸�� ����Ʈ�� ����
            Emotion.Add(NChar);
        }
        //ĳ���͸� ����
        Char.Add(Emotion);
    }

}
