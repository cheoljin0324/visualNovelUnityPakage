using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSPriteSet : MonoBehaviour
{
    /// <summary>
    /// ������Ʈ���� ������ Back�̶�� ���ӿ�����Ʈ ����Ʈ �� ��������Ʈ �迭�� ������ش�.
    /// </summary>
    /// <param name="Back"></param>
    /// <param name="spriteSet"></param>
    public void BackSpriteSet(List<GameObject> Back, Sprite[] spriteSet)
    {
        //������ �ִ� ������Ʈ ��ŭ �ݺ��� ����.
        for(int i = 0; i<Back.Count; i++)
        {
            //Back�� �ִ� ������Ʈ ���ο� ��������Ʈ������ ��� ������Ʈ�� ĳ�� �ش� ������Ʈ�� ��������Ʈ�� spriteSet�� i�� ����
            Back[i].GetComponent<SpriteRenderer>().sprite = spriteSet[i];
            //������Ʈ �켱 ������ ����� 1(������) -> 0(���̾�α� �� �ؽ�Ʈ) -> -1(ĳ���� or �̺�Ʈ CG) -> -2(���)
            Back[i].GetComponent<SpriteRenderer>().sortingOrder = -2;
            //��� �÷����� 0���� �ʱ�ȭ
            Back[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
    }

}
