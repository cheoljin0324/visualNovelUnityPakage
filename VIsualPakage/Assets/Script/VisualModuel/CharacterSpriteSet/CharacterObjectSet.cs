using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterObjectSet : MonoBehaviour
{
    public GameObject PlayPrefab;
    [HideInInspector]
    public List<GameObject> ObjectList = new List<GameObject>();
    public List<GameObject> BObjectList = new List<GameObject>();


    public void DelObject()
    {
       for(int i = 0; i<ObjectList.Count; i++)
        {
            if(charOb.BObjectList.Count == 0 || ObjectList[i].GetComponent<SpriteRenderer>().sprite != BObjectList[i].GetComponent<SpriteRenderer>().sprite)
            {
                ObjectList[i].GetComponent<SpriteRenderer>().DOFade(0f, 0.5f);
            }

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
        BObjectList.Clear();
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i<ObjectList.Count; i++)
        {
            BObjectList.Add(ObjectList[i]);
            Destroy(ObjectList[i]);
        }
        ObjectList.Clear();
    }
}
