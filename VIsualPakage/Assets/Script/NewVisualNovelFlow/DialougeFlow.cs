using System.Collections;
using System.Collections.Generic;
using DSFEngine;
using UnityEngine;



    public class DialougeFlow : MonoBehaviour
    {

    [SerializeField]
    SayScript Say;

    [SerializeField]
    Effect Effect;

    [SerializeField]
    DialogueCLS charData;

    public void Start()
    {
        Say.Say("�ȳ��ϼ���");
        Say.Say("�ݰ����ϴ�");
    }


    }


