using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialFlow : MonoBehaviour
{
    [SerializeField]
    VisualNovelControler vi;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => vi.UpdateDialogue());
    }

}
