using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSet : MonoBehaviour
{
    public EventSet[] eventSet;
    public DialogueIs[] dialogue;
    public BackSprite[] backSprite;
    public SimCharacter[] simChar;
    [HideInInspector]
    public bool isFirst = true;
    [HideInInspector]
    public int currentDialogueIndex = 0;
    public int currentCharIndex = 0;
}
