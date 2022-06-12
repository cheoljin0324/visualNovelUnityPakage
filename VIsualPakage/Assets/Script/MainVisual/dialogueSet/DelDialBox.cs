using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelDialBox : MonoBehaviour
{
    //다이얼 박스 생성
    InstantiateDialBox inst;
    //페이드 할 수 있는 다이얼 박스
    FadeDialBox fade;

    public void Awake()
    {
        //캐싱
        inst = GetComponent<InstantiateDialBox>();
        fade = GetComponent<FadeDialBox>();
    }

    //다이얼로그 오브젝트 삭제
    public void DelObject()
    {
        fade.DelDialFade(inst.DialBox);
        StartCoroutine(Del());
    }

    //페이드 이후 삭제 할 수 있는 코루틴
    public IEnumerator Del()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(inst.DialBox);
    }
}
