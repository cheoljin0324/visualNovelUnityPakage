using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelDialBox : MonoBehaviour
{

    InstantiateDialBox inst;
    FadeDialBox fade;

    public void Awake()
    {
        inst = GetComponent<InstantiateDialBox>();
        fade = GetComponent<FadeDialBox>();
    }

    public void DelObject()
    {
        fade.DelDialFade(inst.DialBox);
        StartCoroutine(Del());
    }

    public IEnumerator Del()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(inst.DialBox);
    }
}
