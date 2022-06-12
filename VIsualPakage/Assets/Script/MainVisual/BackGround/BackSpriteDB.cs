using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("DialoguePackage/BackSetting")]
[RequireComponent(typeof(BackSPriteSet))]
[RequireComponent(typeof(BackSpriteOb))]
[RequireComponent(typeof(InstBackGround))]
[RequireComponent(typeof(BackControl))]

public class BackSpriteDB : MonoBehaviour
{
    [Header("���� ���")]
    public Sprite[] backSprite;
}
