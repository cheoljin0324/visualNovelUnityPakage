using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelDialBox : MonoBehaviour
{
    //���̾� �ڽ� ����
    InstantiateDialBox inst;
    //���̵� �� �� �ִ� ���̾� �ڽ�
    FadeDialBox fade;

    public void Awake()
    {
        //ĳ��
        inst = GetComponent<InstantiateDialBox>();
        fade = GetComponent<FadeDialBox>();
    }

    //���̾�α� ������Ʈ ����
    public void DelObject()
    {
        fade.DelDialFade(inst.DialBox);
        StartCoroutine(Del());
    }

    //���̵� ���� ���� �� �� �ִ� �ڷ�ƾ
    public IEnumerator Del()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(inst.DialBox);
    }
}
