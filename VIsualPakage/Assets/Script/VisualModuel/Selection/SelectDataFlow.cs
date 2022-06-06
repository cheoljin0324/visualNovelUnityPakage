using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectDataFlow : MonoBehaviour
{
    TextDataSet textData;
    bool selectIn = false;
    bool instButton = true;
    public int result = 0;
    [Header("���̵带 ���� ������Ʈ(������ ��������Ʈ �ϳ� ����ָ� �˴ϴ�)")]
    public GameObject FadeOb;


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
            StartCoroutine(Fade());
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
            StartCoroutine(FadeOut());
            selectIn = true;
            result = textData.obEle.resultNum;
        }

        return selectIn;
    }

    IEnumerator Fade()
    {
        FadeOb.GetComponent<SpriteRenderer>().DOFade(0.5f, 1);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator FadeOut()
    {
        FadeOb.GetComponent<SpriteRenderer>().DOFade(0f, 0.5f);
        yield return new WaitForSeconds(1f);
    }
}
