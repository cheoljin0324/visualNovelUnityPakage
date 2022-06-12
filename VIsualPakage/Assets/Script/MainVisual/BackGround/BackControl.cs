using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackControl : MonoBehaviour
{
    //��� ���� Ŭ������ ����
    InstBackGround insBack;
    //��� ��������Ʈ �ʱ�ȭ�� ����
    BackSPriteSet backSp;  
    //��� ������Ʈ
    BackSpriteOb backSpriteOB;
    //��� ����
    BackSpriteDB backSPrite;

    //��� ������Ʈ ���� ���� ����Ʈ
    public List<GameObject> BackOBject;

    public void Awake()
    {
        //ĳ��
        insBack = GetComponent<InstBackGround>();
        backSp = GetComponent<BackSPriteSet>();
        backSpriteOB = GetComponent<BackSpriteOb>();
        backSPrite = GetComponent<BackSpriteDB>();
    }

    /// <summary>
    /// ���־�뺧 ��Ʈ�ѷ����� ���� ��� ������(��Ȯ���� ������ �÷��ִ°���) 
    /// </summary>
    /// <param name="useBack"></param>
    public void InSetting(int useBack)
    {
        BackOBject[useBack].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    /// <summary>
    /// ���־�뺧 ��Ʈ�ѷ����� ���� ��� ������(��Ȯ���� ������ �����ִ°���)
    /// </summary>
    /// <param name="outBack"></param>
    public void OutSetting(int outBack)
    {
        BackOBject[outBack].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    /// <summary>
    /// ��� ����
    /// </summary>
    public void BackInstantiate()
    {
        insBack.InstantBack(BackOBject,backSpriteOB.backGameOB,backSPrite.backSprite.Length);
    }

    /// <summary>
    /// �ʱ� ��� �ʱ�ȭ
    /// </summary>
    public void backSpriteSet()
    {
        backSp.BackSpriteSet(BackOBject, backSPrite.backSprite);
    }
   
}
