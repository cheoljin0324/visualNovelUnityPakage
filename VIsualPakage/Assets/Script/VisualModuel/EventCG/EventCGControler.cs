using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCGControler : MonoBehaviour
{
    OnOffCG SetObject;
    EventSpriteSet eventSpriteSet;
    EventCreate InstEvent;
    VisualSet dataSet;

    private void Awake()
    {
        SetObject = GetComponent<OnOffCG>();
        eventSpriteSet = GetComponent<EventSpriteSet>();
        InstEvent = GetComponent<EventCreate>();
        dataSet = GetComponent<VisualSet>();
    }

    public void OnEventCG(int index)
    {
        if(dataSet.dialogue[dataSet.currentDialogueIndex].dialogueEvent == DialogueIs.DialogueEven.EventCG)
        {
            SetObject.OnCGIN(index);
        }

    }

    public void OffEventCG(int index)
    {
        if (dataSet.dialogue[dataSet.currentDialogueIndex].dialogueEvent == DialogueIs.DialogueEven.EventCG)
        {
            SetObject.OffCgOut(index);
        }

    }

    public void eventSpriteSets()
    {
        if (dataSet.dialogue[dataSet.currentDialogueIndex].dialogueEvent == DialogueIs.DialogueEven.EventCG)
        {
            eventSpriteSet.SpriteSet();
        }

    }

    public void CreateEvent()
    {
        if (dataSet.dialogue[dataSet.currentDialogueIndex].dialogueEvent == DialogueIs.DialogueEven.EventCG)
        {
            InstEvent.CreateEvent();
        }

    }
}
