using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDataFlow : MonoBehaviour
{
    TextDataSet textData;
    bool selectIn = false;
    bool instButton = true;
    public int result = 0;


    private void Awake()
    {
        //�ؽ�Ʈ �����͸� ĳ��
        textData = GetComponent<TextDataSet>();
    }
    public bool SetNext()
    {
        //���� instButton�� Ʈ���
        if (instButton == true)
        {
            //textData�� ����Ʈ ������ŭ
            for (int i = 0; i < textData.dataSet.selectionList.Count; i++)
            {
                //������ ��ŭ ��ư ����
                textData.obEle.Element();
            }
            //������ �ʱ�ȭ
            textData.DataSet();
            //��ġ �ʱ�ȭ
            textData.obEle.ButtonPosSet();
            //������ �ֱ�
            textData.obEle.SetOnclick();
            //instButton�� ����.
            instButton = false;
        }
        if (textData.obEle.Set == true)
        {
            selectIn = true;
            result = textData.obEle.resultNum;
        }

        return selectIn;
    }
}
