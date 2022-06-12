using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialDataSet : MonoBehaviour
{
    //�ؽ�Ʈ ���̾�α׸� ���� �����ִ� ����
    TextDialogueSet textDial;
    //�ؽ�Ʈ ��Ʈ�ѷ��� ĳ�����ֱ� ���� ����
    TextControler textCon;
    //Ÿ���� ���ǵ�
    public float TypingSpd = 0.05f;

    private void Awake()
    {
        //�ؽ�Ʈ ���̾�α� ���� ĳ��
        textDial = GetComponent<TextDialogueSet>();
        //�ؽ�Ʈ ��Ʈ�ѷ��� ĳ��
        textCon = GetComponent<TextControler>();

    }

    /// <summary>
    /// ���̾� �����͸� ���� �����ִ� �Լ�
    /// </summary>
    /// <param name="Dial"></param>
    public void DialData(string Dial)
    {
        //Ÿ���� ��ŸƮ �ڷ�ƾ ����
        StartCoroutine("Typing", Dial);
    }

    IEnumerator Typing(string Dial)
    {
        //Ÿ���� ������ ī��Ʈ�� �ε��� ���� ����
        int index = 0;

        //���� Ÿ���� ���̶�� bool ���� true�� ���� ���� ���� Ÿ���� ���̶�� �÷��׸� �����
        textCon.isTyping = true;

        //index�� ���̾� ���� �������� ����
        while(index < Dial.Length+1)
        {
            //�ؽ�Ʈ ���̾� ������Ʈ DialTextN�� ������Ʈ�� ������.
            textDial.DialTextN.GetComponent<Text>().text = Dial.Substring(0, index);
            //�ε��� +=1
            index++;

            //�ؽ�Ʈ ��Ʈ�ѷ��� isTyping�� false �� �ٲ��ش�.
            if (textCon.isTyping == false)
            {
                //�ؽ�Ʈ ���̾��� �̸� �ؽ�Ʈ�� �ʱ�ȭ
                textDial.DialTextN.GetComponent<Text>().text = Dial;
                //�ε����� �־�����ϴ� ���ڿ� ������ ���̰� �ȴ�.
                index = Dial.Length;
            }
            //Ÿ���� ���ǵ� ��ŭ ���
            yield return new WaitForSeconds(TypingSpd);
        }
        //�ؽ�Ʈ ��Ʈ�ѷ��� isTyping�� false �� �ʱ�ȭ
        textCon.isTyping = false;
    }
}
