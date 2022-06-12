using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    //���̾� �ڽ� fade�� ���� ĳ�� ���� ����
    FadeDialBox fadial;
    //Object�� �������� ObjectSet Ŭ������ ����
    ObjectSet ObSet;
    //���̾� �ڽ��� ������� InstantiateDialBox ����
    InstantiateDialBox instDial;
    //���̾� �ڽ��� ������ delDial 
    DelDialBox delDial;

    private void Awake()
    {
        //ĳ��
        fadial = GetComponent<FadeDialBox>();
        ObSet = GetComponent<ObjectSet>();
        instDial = GetComponent<InstantiateDialBox>();
        delDial = GetComponent<DelDialBox>();
    }

    /// <summary>
    /// ���̾� �ڽ� ��
    /// </summary>
    public void DialSet()
    {
        instDial.DialogueBoxSet(ObSet.DialBox);
    }

    /// <summary>
    /// ���̾��� ���ش�.
    /// </summary>
    public void DialOff()
    {
        delDial.DelObject();
    }

    /// <summary>
    /// ���̵�
    /// </summary>
    /// <param name="isFade"></param>
    public void Fade(bool isFade)
    {
        if (isFade == true)
        {
            fadial.InstDialFade(ObSet.DialBox);
        }
        else
        {
            fadial.DelDialFade(ObSet.DialBox);
        }
    }
}
