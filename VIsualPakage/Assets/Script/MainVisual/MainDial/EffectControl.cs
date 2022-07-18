using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EffectControl : MonoBehaviour
{
    private VisualNovelControler visual;

    private void Awake()
    {
        visual = GetComponent<VisualNovelControler>();
    }

    public void Angry(GameObject character)
    {
        visual.isangry = true;
        StartCoroutine(AngrySet(character));
    }

    public void Zoomin(GameObject character)
    {
        character.transform.localScale = new Vector3(character.transform.localScale.x * 3, character.transform.localScale.y * 3, character.transform.localScale.z);
        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y - 3f, character.transform.position.z);
    }

    public void Zoomoff(GameObject character)
    {
        character.transform.localScale = new Vector3(character.transform.localScale.x / 3, character.transform.localScale.y / 3, character.transform.localScale.z);
        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 3f, character.transform.position.z);
    }


    IEnumerator AngrySet(GameObject angrySet)
    {
       for(int i = 0; i<5; i++)
       {
            angrySet.transform.DOMove(new Vector3(angrySet.transform.position.x, angrySet.transform.position.y+0.3f, angrySet.transform.position.z), 0.1f, false);
            yield return new WaitForSeconds(0.1f);
            angrySet.transform.DOMove(new Vector3(angrySet.transform.position.x, angrySet.transform.position.y + 0.3f, angrySet.transform.position.z), 0.1f, false);
            yield return new WaitForSeconds(0.1f);
        }
        visual.isangry = true;
    }
}
