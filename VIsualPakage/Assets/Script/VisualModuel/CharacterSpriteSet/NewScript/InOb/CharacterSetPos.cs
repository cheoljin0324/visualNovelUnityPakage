using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetPos : MonoBehaviour
{
    public Vector2[] SetPos;

    public void SetPosition(int SPos, GameObject charOb)
    {
        charOb.transform.position = SetPos[SPos];
    }
}
