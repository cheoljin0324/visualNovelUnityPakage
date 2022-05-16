using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPositionSet : MonoBehaviour
{
    public Vector3 NamePosition;
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
