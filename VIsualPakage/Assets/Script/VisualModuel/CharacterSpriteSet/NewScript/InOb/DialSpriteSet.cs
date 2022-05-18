using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialSpriteSet : MonoBehaviour
{
    /// <summary>
    /// ��������Ʈ �ʱ�ȭ ����Ʈ ���ӿ�����Ʈ or ��������Ʈ �迭
    /// </summary>
    /// <param name="newOb"></param>
    /// <param name="SetSprite"></param>
    public void SpriteSet(List<GameObject> newOb,Sprite[] SetSprite)
    {
        //newOb��� ������Ʈ ī��Ʈ
        for(int i = 0; i<newOb.Count; i++)
        {
            //newOb�� �ش� ��������Ʈ�� ĳ�� �� �ش� ������Ʈ�� ��������Ʈ�� SetSprite�� �ش� ��ȣ�� �ʱ�ȭ
            newOb[i].GetComponent<SpriteRenderer>().sprite = SetSprite[i];
            //������Ʈ �÷��� �ʱ�ȭ
            newOb[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            //������Ʈ�� �켱������ -1�� �����.
            newOb[i].GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }
}
