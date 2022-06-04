using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPositionSet : MonoBehaviour
{
    [Header("�̸��� ��ġ")]
    public Vector3 NamePosition;
    [Header("��ȭ���� ������")]
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
