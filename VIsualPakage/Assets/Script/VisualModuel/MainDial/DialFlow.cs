using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialFlow : MonoBehaviour
{
    [SerializeField]
    VisualNovelControler vi;
    [SerializeField]
    VisualNovelControler vi2;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => vi.UpdateDialogue());
    }

}
