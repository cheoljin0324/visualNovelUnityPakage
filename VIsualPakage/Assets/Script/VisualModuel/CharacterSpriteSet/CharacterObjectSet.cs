using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterObjectSet : MonoBehaviour
{
    public GameObject PlayPrefab;
    public float delTime = 0.1f;
    [HideInInspector]
    public List<GameObject> ObjectList = new List<GameObject>();
    public List<GameObject> BObjectList = new List<GameObject>();
    public float fadeTime = 0.1f;


    public void DelObject()
    {
        StartCoroutine(delOb());
    }

    public void NdelObject()
    {
        for (int i = 0; i < ObjectList.Count; i++)
        {
            Destroy(ObjectList[i]);
        }
    }
   

    public void NewObject(int length) {
        ObjectList.Clear();
        for(int i = 0; i<length; i++)
        {
            ObjectList.Add(Instantiate(PlayPrefab.gameObject));
            ObjectList[i].GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }

    private IEnumerator delOb()
    {
        yield return new WaitForSeconds(delTime);
        for(int i = 0; i<ObjectList.Count; i++)
        {
            Destroy(ObjectList[i]);
        }
    }
}
