using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialFlow : MonoBehaviour
{
    //���־�뺧 ������Ʈ
    [SerializeField]
    VisualNovelControler vi;
    [SerializeField]
    VisualNovelControler vi2;

    /// <summary>
    /// �ڷ�ƾ ������ ���� ���� �̾���
    /// </summary>
    /// <returns></returns>
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => vi.UpdateDialogue());
    }

}
