using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetPos : MonoBehaviour
{
    //��ġ�� ���� ���� �迭
    public Vector2[] SetPos;

    /// <summary>
    /// ĳ���� �Ӽ����� ��ġ�� Ư�� ��ġ�� ����
    /// </summary>
    /// <param name="SPos"></param>
    /// <param name="charOb"></param>
    public void SetPosition(int SPos, GameObject charOb)
    {
        charOb.transform.position = SetPos[SPos];
    }
}
