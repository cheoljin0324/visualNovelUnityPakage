using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetPosition : MonoBehaviour
{
    public Vector3[] pos;
    CharacterObjectSet obSet;

    private void Awake()
    {
        obSet = GetComponent<CharacterObjectSet>();
    }

    public void SetPos(int[] posVal)
    {
        for(int i = 0; i<posVal.Length; i++)
        {
            if (posVal[i] == 0)
            {
                obSet.ObjectList[i].transform.position = pos[0];
            }
            else if (posVal[i] == 1)
            {
                obSet.ObjectList[i].transform.position = pos[1];
            }
            else
            {
                obSet.ObjectList[i].transform.position = pos[2];
            }

        }
    }
}
