using System.Collections;
using System.Collections.Generic;
using DSFEngine;
using UnityEngine;


//Say("��ȭ ����, ����� ĳ���� ���̵�, �ش� ĳ������ ǥ��(����), ���Ǵ� ���(����), ĳ������ ��ġ(����-0����,1���,2������))"
//Say("��ȭ ����, ù��° ĳ���� ���̵�, �ι�° ĳ���� ���̵�, ù ��° ĳ���� ����(����), �� ��° ĳ���� ����(����), ���(����), ���ϴ� ĳ����(ù ��°(1),�� ��°(2)), ù ��° ĳ���� ��ġ, �� ��° ĳ���� ��ġ)

public class DialougeFlow : ScritControler
{

    [SerializeField]
    SayScript Say;

    [SerializeField]
    Effect Effect;

    [SerializeField]
    DialogueCLS charData;

    public void Start()
    {
        Say.Say("�ȳ�");
    }


    }


