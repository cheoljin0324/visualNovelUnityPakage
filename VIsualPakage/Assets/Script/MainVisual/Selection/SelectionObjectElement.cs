using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObjectElement : MonoBehaviour
{
    SelectObject select;

    public bool Set = false;
    public int resultNum = 0;
    public List<GameObject> SelectObjectList;
    public List<int> ResultNumber;
    GameObject nowObject;

    public int a = 0;

    private void Awake()
    {
        select = GameObject.Find("Selection").GetComponent<SelectObject>();

    }

    public void Element()
    {
            nowObject = Instantiate(select.SelectButtonObject);
            nowObject.transform.SetParent(GameObject.Find("Canvas").transform);
            SelectObjectList.Add(nowObject);
    }

    public void SetOnclick()
    {
        for(int i = 0; i < SelectObjectList.Count; i++)
        {
            ResultNumber.Add(i);
        }
        switch (SelectObjectList.Count)
        {
            case 1:
                SelectObjectList[0].GetComponent<Button>().onClick.AddListener(() => FSetNum());
                break;
            case 2:
                SelectObjectList[0].GetComponent<Button>().onClick.AddListener(() => FSetNum());
                SelectObjectList[1].GetComponent<Button>().onClick.AddListener(() => SSetNum());
                break;
            case 3:
                SelectObjectList[0].GetComponent<Button>().onClick.AddListener(() => FSetNum());
                SelectObjectList[1].GetComponent<Button>().onClick.AddListener(() => SSetNum());
                SelectObjectList[2].GetComponent<Button>().onClick.AddListener(() => TSetNum());
                break;
            case 4:
                SelectObjectList[0].GetComponent<Button>().onClick.AddListener(() => FSetNum());
                SelectObjectList[1].GetComponent<Button>().onClick.AddListener(() => SSetNum());
                SelectObjectList[2].GetComponent<Button>().onClick.AddListener(() => TSetNum());
                SelectObjectList[3].GetComponent<Button>().onClick.AddListener(() => FDSetNum());
                break;
        }
    }

    public void FSetNum()
    {
        for(int j = 0; j<SelectObjectList.Count; j++)
        {
            SelectObjectList[j].SetActive(false);
        }
        Set = true;
        resultNum = 1;
        Debug.Log(1);
    }

    public void SSetNum()
    {
        for (int j = 0; j < SelectObjectList.Count; j++)
        {
            SelectObjectList[j].SetActive(false);
        }
        Set = true;
        resultNum = 2;
        Debug.Log(2);
    }

    public void TSetNum()
    {
        for (int j = 0; j < SelectObjectList.Count; j++)
        {
            SelectObjectList[j].SetActive(false);
        }
        Set = true;
        resultNum = 3;
        Debug.Log(3);
    }

    public void FDSetNum()
    {
        for (int j = 0; j < SelectObjectList.Count; j++)
        {
            SelectObjectList[j].SetActive(false);
        }
        Set = true;
        resultNum = 4;
        Debug.Log(4);
    }

    public void ButtonPosSet()
    {
        switch (SelectObjectList.Count)
        {
            case 1:
                SelectObjectList[0].transform.localPosition = select.newPos[0].SetPos[0];
                break;
            case 2:
                for(int i = 0; i<SelectObjectList.Count; i++)
                {
                    SelectObjectList[i].transform.localPosition = select.newPos[1].SetPos[i];
                }
                break;
            case 3:
                for (int i = 0; i < SelectObjectList.Count; i++)
                {
                    SelectObjectList[i].transform.localPosition = select.newPos[2].SetPos[i];
                }
                break;
            case 4:
                for (int i = 0; i < SelectObjectList.Count; i++)
                {
                    SelectObjectList[i].transform.localPosition = select.newPos[3].SetPos[i];
                }
                break;
        }
    }
}
