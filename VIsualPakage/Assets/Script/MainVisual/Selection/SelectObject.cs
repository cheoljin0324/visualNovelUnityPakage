using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField]
    public GameObject SelectButtonObject;
    [SerializeField]
    public PosSet[] newPos;
}

[System.Serializable]
public struct PosSet
{
    [SerializeField]
    public Vector3[] SetPos;
}
