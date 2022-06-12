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
    //사용되는 오브젝트 창구
    [SerializeField]
    public GameObject DialBox;
    [SerializeField]
    public GameObject DialArrow;
    [SerializeField]
    public GameObject DialName;
    [SerializeField]
    public GameObject DialText;

}
