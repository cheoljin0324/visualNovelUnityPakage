using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControler : MonoBehaviour
{
    //���̾� �ڽ� ������ ���� Ŭ����
    DelDialBox delDial;
    //���̾� �ڽ� ������ ���� Ŭ����
    InstantiateDialBox instDialBox;
    //���̵带 ���� Ŭ����
    FadeDialBox FadeControl;

    //���̾� �ڽ� ������Ʈ ����
    public GameObject DialBox;

    private void Awake()
    {
        //������Ʈ ĳ��
        delDial = GetComponent<DelDialBox>();
        instDialBox = GetComponent<InstantiateDialBox>();
        FadeControl = GetComponent<FadeDialBox>();
    }

    /// <summary>
    /// ������Ʈ ����
    /// </summary>
    public void deleteDial()
    {
        delDial.DelObject();
    }

    /// <summary>
    /// ���ο� ���̾� �α� ���� �� �ʱ�ȭ
    /// </summary>
    /// <param name="Dial"></param>
    public void NewDial(GameObject Dial)
    {
        instDialBox.DialogueBoxSet(Dial);
        DialBox = instDialBox.DialBox;
        FadeControl.InstDialFade(instDialBox.DialBox);
    }

    //���̵� �ƿ�������Ʈ
    public void FadeOutDial(GameObject Dial)
    {
        FadeControl.DelDialFade(Dial);
    }

}
