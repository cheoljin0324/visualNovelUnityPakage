using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VisualSet : MonoBehaviour
{

    //���Ǵ� ������ SET �ʱ�ȭ
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
