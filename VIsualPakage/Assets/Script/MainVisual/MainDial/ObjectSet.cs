using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("DialoguePackage/DialSetting")]
[RequireComponent(typeof(DelDialBox))]
[RequireComponent(typeof(FadeDialBox))]
[RequireComponent(typeof(InstantiateDialBox))]
[RequireComponent(typeof(DialogueControler))]
public class ObjectSet : MonoBehaviour
{
    //���Ǵ� ������Ʈ â��
    [SerializeField]
    public GameObject DialBox;
    [SerializeField]
    public GameObject DialArrow;
    [SerializeField]
    public GameObject DialName;
    [SerializeField]
    public GameObject DialText;

}
