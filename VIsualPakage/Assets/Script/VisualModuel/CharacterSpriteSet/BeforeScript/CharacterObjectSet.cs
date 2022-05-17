using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterObjectSet : MonoBehaviour
{
    public GameObject PlayPrefab;
    public float delTime = 0.2f;
    [HideInInspector]
    public List<GameObject> ObjectList = new List<GameObject>();
    public List<GameObject> BObjectList = new List<GameObject>();
    public float fadeTime = 0.1f;


    public void DelObject(int length)
    {
        StartCoroutine(delOb(length));
    }
   

    public void NewObject(int length) {;
        for(int i = 0; i<length; i++)
        {
            ObjectList.Add(Instantiate(PlayPrefab.gameObject));
            ObjectList[i].GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }

    private IEnumerator delOb(int length)
    {
        yield return new WaitForSeconds(delTime);
        for(int i = 0; i<=length+1; i++)
        {
            Destroy(ObjectList[i]);
            Debug.Log(length);
            ObjectList.RemoveAt(i);
        }
    }
}
