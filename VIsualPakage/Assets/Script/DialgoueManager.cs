using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DialgoueManager : MonoBehaviour
{
    [SerializeField]
    private VisualNovelReReady[] ChapterOne;
    [SerializeField]
    private LoadScreen loadFade;

    [SerializeField]
    private Sprite[] CGSprite;
    [SerializeField]
    private SpriteRenderer leanSprite;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => ChapterOne[0].UpdateDialogue());
        loadFade.inFade();
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => CgSet(0));

        yield return new WaitForSeconds(0.1f);

        yield return new WaitUntil(() => ChapterOne[1].UpdateDialogue());
    }

    private bool CgSet(int i)
    {
        leanSprite.gameObject.SetActive(true);
        leanSprite.sprite = CGSprite[i];

        if (Input.GetMouseButtonDown(0))
        { 
            return true;
        }
        return false;
    }
}
