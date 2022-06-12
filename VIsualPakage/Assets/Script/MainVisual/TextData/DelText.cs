using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DelText : MonoBehaviour
{

    /// <summary>
    /// ������Ʈ ���� �Լ�
    /// </summary>
    /// <param name="TextSet"></param>
  public void DelOb(GameObject TextSet)
    {
        //�ؽ�Ʈ �κ��� ĳ�� �� �� DOFade�� ���� ���̵� ȿ�� ����
        TextSet.GetComponent<Text>().DOFade(0f, 0.5f);
        //DesOb��� �ڷ�ƾ ����
        StartCoroutine(DesOb(TextSet));
    }

    IEnumerator DesOb(GameObject TextSet)
    {
        //���̵带 �۾� �ϴ� 0.5�� �۾� ��
        yield return new WaitForSeconds(0.5f);
        //TextSet�̶�� ���� ������Ʈ�� ���ش�.
        TextSet.gameObject.SetActive(false);
    }
}
