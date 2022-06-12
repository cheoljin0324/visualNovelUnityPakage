using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelOb : MonoBehaviour
{
    /// <summary>
    /// 삭제될 오브젝트를 매개변수로 받은 후 리스트 개수만큼 삭제
    /// </summary>
    /// <param name="DelingOb"></param>
   public void DeleteOB(List<GameObject> DelingOb)
    {
        for(int i = 0; i<DelingOb.Count; i++)
        {
            Destroy(DelingOb[i]);
        }
    }
}
