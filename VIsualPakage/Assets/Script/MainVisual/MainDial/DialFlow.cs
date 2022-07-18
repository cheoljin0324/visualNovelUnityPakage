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
    [SerializeField]
    VisualNovelControler v3;

    [SerializeField]
    VisualNovelControler[] vA;

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
        yield return new WaitForSeconds(2f);
        if (flow.result == 1)
        {
            Debug.Log(1);
            yield return new WaitUntil(() => v3.UpdateDialogue());
        }
        else if(flow.result ==2)
        {
            Debug.Log(2);
            yield return new WaitUntil(() => vi2.UpdateDialogue());
        }
        else
        {
            Debug.Log(3);
            yield return new WaitUntil(() => v3.UpdateDialogue());
        }

    }

}
