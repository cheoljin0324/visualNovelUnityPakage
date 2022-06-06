using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialFlow : MonoBehaviour
{
    //���־�뺧 ������Ʈ
    [SerializeField]
    VisualNovelControler vi;
    [SerializeField]
    SelectDataFlow flow;
    [SerializeField]
    VisualNovelControler vi2;

    BackControl backCon;
    void Awake()
    {
        backCon = GameObject.Find("BackSprite").GetComponent<BackControl>();
        backCon.BackInstantiate();
        backCon.backSpriteSet();

    }

    /// <summary>
    /// �ڷ�ƾ ������ ���� ���� �̾���
    /// </summary>
    /// <returns></returns>
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => vi.UpdateDialogue());
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => flow.SetNext());
        yield return new WaitForSeconds(1f);
        if (flow.result == 1)
        {
            Debug.Log(1);
            yield return new WaitUntil(() => vi2.UpdateDialogue());
        }
        else
        {
            Debug.Log(2);
            yield return new WaitUntil(() => vi2.UpdateDialogue());
        }

    }

}
