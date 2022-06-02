using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialFlow : MonoBehaviour
{
    //비주얼노벨 오브젝트
    [SerializeField]
    VisualNovelControler vi;
    [SerializeField]
    SelectDataFlow flow;

    /// <summary>
    /// 코루틴 값으로 시작 이후 이어짐
    /// </summary>
    /// <returns></returns>
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => vi.UpdateDialogue());
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => flow.SetNext());
    }

}
