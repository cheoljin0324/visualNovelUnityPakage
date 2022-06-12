using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreate : MonoBehaviour
{
    VisualSet dataset;

    [SerializeField]
    private GameObject eventObject;

    public List<GameObject> eventCGList;
    GameObject eventCG;

    private void Awake()
    {
        dataset = GetComponent<VisualSet>();
    }

    public void CreateEvent()
    {
        for(int i = 0; i<dataset.eventSet.Length; i++)
        {
            eventCG = Instantiate(eventObject);
            eventCGList.Add(eventCG);
        }
    }
}
