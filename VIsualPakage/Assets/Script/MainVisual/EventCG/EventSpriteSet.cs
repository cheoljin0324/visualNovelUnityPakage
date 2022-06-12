using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpriteSet : MonoBehaviour
{
    EventCreate eventCreate;
    VisualSet dataset;

    private void Awake()
    {
        eventCreate = GetComponent<EventCreate>();
        dataset = GetComponent<VisualSet>();
    }

    public void SpriteSet()
    {
        for(int i = 0; i<eventCreate.eventCGList.Count; i++)
        {
            eventCreate.eventCGList[i].GetComponent<SpriteRenderer>().sprite = dataset.eventSet[i].EventCG;
            eventCreate.eventCGList[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

}
