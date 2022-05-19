using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBackGround : MonoBehaviour
{
    //��׶��� ��������Ʈ ������Ʈ�� �ҷ��� �����ϱ� ���� �ڵ�
    BackSpriteOb backOb;

    void Awake()
    {
        //backOB�� BackSpriteOb�� ĳ��
        backOb = GetComponent<BackSpriteOb>();
    }

    /// <summary>
    /// ������Ʈ�� ������ ����Ʈ �׸��� ������ ��׶��� ���������� ���� ��� ��������Ʈ ������ ������ ������ ������ �Ű������� ���� ������Ʈ�� ���� ��Ű�� �ִ� ��������Ʈ ��ŭ �������ִ� �Լ� ����
    /// </summary>
    /// <param name="gameBackList"></param>
    /// <param name="backGround"></param>
    /// <param name="backAmount"></param>
    public void InstantBack(List<GameObject> gameBackList,GameObject backGround,int backAmount)
    {
        //������ �ִ� �� ��������Ʈ ��ŭ �ݺ�
        for(int i = 0; i<backAmount; i++)
        {
            //��׶��� �� ��������Ʈ ���� �� �־��ش�
            backGround = Instantiate(backOb.backGameOB);
            //�־��� backGround ��������Ʈ�� gameBackList��� ������Ʈ ����Ʈ�� �־��ش�.
            gameBackList.Add(backGround);
        }

    }
}
