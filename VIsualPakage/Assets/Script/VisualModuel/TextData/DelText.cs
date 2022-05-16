using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DelText : MonoBehaviour
{
  public void DelOb(GameObject TextSet)
    {
        TextSet.GetComponent<Text>().DOFade(0f, 0.5f);
        StartCoroutine(DesOb(TextSet));
    }

    IEnumerator DesOb(GameObject TextSet)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(TextSet);
    }
}
