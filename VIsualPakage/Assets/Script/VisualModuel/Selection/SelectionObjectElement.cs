using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionObjectElement : MonoBehaviour
{
    SelectObject select;

    public List<GameObject> SelectObjectList;
    GameObject nowObject;

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
