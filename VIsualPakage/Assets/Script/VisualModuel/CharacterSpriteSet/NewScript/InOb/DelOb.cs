using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelOb : MonoBehaviour
{
    /// <summary>
    /// ������ ������Ʈ�� �Ű������� ���� �� ����Ʈ ������ŭ ����
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
