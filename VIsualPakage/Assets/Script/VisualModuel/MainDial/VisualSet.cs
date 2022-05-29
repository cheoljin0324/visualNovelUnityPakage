using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VisualSet : MonoBehaviour
{

    //사용되는 데이터 SET 초기화
    public EventSet[] eventSet;
    public DialogueIs[] dialogue;
    public SimCharacter[] simChar;
    [HideInInspector]
    public bool isFirst = true;
    [HideInInspector]
    public bool isLastDial = false;
    [HideInInspector]
    public bool isFade = false;
    [HideInInspector]
    public int currentDialogueIndex = 0;
    [HideInInspector]
    public int currentCharIndex = 0;
}
