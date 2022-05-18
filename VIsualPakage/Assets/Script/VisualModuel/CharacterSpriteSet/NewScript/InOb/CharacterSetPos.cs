using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetPos : MonoBehaviour
{
    //위치를 받을 벡터 배열
    public Vector2[] SetPos;

    /// <summary>
    /// 캐릭터 속성값의 위치를 특정 위치로 변경
    /// </summary>
    /// <param name="SPos"></param>
    /// <param name="charOb"></param>
    public void SetPosition(int SPos, GameObject charOb)
    {
        charOb.transform.position = SetPos[SPos];
    }
}
