using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffCG : MonoBehaviour
{
    EventCreate eventCreate;

    private void Awake()
    {
        eventCreate = GetComponent<EventCreate>();
    }

    public void OnCGIN(int index)
    {
        eventCreate.eventCGList[index].GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }

    public void OffCgOut(int index)
    {
        eventCreate.eventCGList[index].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
}
