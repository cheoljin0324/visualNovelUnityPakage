using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("DialoguePackage/CharacterSetting")]
[RequireComponent(typeof(InstCharacterOb))]
[RequireComponent(typeof(CharacterSetPos))]
[RequireComponent(typeof(DelOb))]
[RequireComponent(typeof(DialSpriteSet))]

public class charData : MonoBehaviour
{
    //게임 오브젝트 생성
    public GameObject Inst;
}
