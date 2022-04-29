using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DialgoueManager : MonoBehaviour
{
    [SerializeField]
    private VisualNovelReReady ChapterOne;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => ChapterOne.UpdateDialogue());
    }
}
