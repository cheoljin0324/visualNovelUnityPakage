using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPositionSet : MonoBehaviour
{
    [Header("이름의 위치")]
    public Vector3 NamePosition;
    [Header("대화형의 움직임")]
    public Vector3 DialPosition;


    public void NamePosSet(GameObject Name)
    {
        Name.transform.localPosition = NamePosition;
        
    }

    public void DialPosSet(GameObject Dial)
    {
        Dial.transform.localPosition = DialPosition;
    }
}
