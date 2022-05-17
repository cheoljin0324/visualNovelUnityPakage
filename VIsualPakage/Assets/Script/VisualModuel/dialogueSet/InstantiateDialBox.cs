using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDialBox : MonoBehaviour
{
    //���̾� �ڽ��� �����ؼ� ���� ��ų ������Ʈ�� �������·� ��ȯ
    [HideInInspector]
    public GameObject DialBox;
    //���̵� ȿ���� ���� ���̵� ���̾� �ڽ� ĳ��
    FadeDialBox fade;

    public void Awake()
    {
        //���̵� ĳ��
        fade = GetComponent<FadeDialBox>();
    }

    public void DialogueBoxSet(GameObject dialogueBox)
    {
        //���̾� �ڽ��� ����
        DialBox = Instantiate(dialogueBox);
        //�÷����� �����ϰ� �ʱ�ȭ
        DialBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);//�� �κ��� ���߿� (1,1,1,0)���� �� �ٲ� ��
        //���̵�
        fade.InstDialFade(DialBox);
    }

}
