using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterObjectSet : MonoBehaviour
{
    public GameObject PlayPrefab;
    [HideInInspector]
    public List<GameObject> ObjectList = new List<GameObject>();


    public void DelObject()
    {
       for(int i = 0; i<ObjectList.Count; i++)
        {
            ObjectList[i].GetComponent<SpriteRenderer>().DOFade(0f, 0.5f);
        }
        StartCoroutine(delOb());
    }

    public void NewObject(int length) {
        for(int i = 0; i<length; i++)
        {
            ObjectList.Add(Instantiate(PlayPrefab.gameObject));
            ObjectList[i].GetComponent<SpriteRenderer>().sortingOrder = -1;
            ObjectList[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

    private IEnumerator delOb()
    {
        yield return new WaitForSeconds(0.5f);
        ObjectList.Clear();
    }
}
