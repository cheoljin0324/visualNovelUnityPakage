using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDataSet : MonoBehaviour
{
    //�ؽ�Ʈ ���Ӽ��� ĳ���ϱ� ���� ���� ����
    TextNameSet nameSet;

    private void Awake()
    {
        //���� �� ĳ��
        nameSet = GetComponent<TextNameSet>();
    }

    /// <summary>
    /// ������ �ʱ�ȭ ���ִ� �Լ�
    /// </summary>
    /// <param name="Name"></param>
    public void NameData(string Name)
    {
        //���Ӽ¿� �ؽ�Ʈ ������Ʈ�� ĳ�� �� �ش� �ؽ�Ʈ�� �̸���  �ʱ�ȭ
        nameSet.NameTextN.GetComponent<Text>().text = Name;
    }
}
