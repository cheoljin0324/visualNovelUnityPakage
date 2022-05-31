using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionObjectElement : MonoBehaviour
{
    SelectObject select;
    SelectionDataSetting selection;
    List<GameObject> SelectObjectList;
    GameObject nowObject;

    private void Awake()
    {
        select = GameObject.Find("Selection").GetComponent<SelectObject>();
        selection = GetComponent<SelectionDataSetting>();
    }

    public void Element()
    {
        for(int i = 0; i< selection.selectionList.Count; i++)
        {
            nowObject = Instantiate(select.SelectButtonObject);
            SelectObjectList.Add(nowObject);
        }
    }

    public void ButtonPosSet()
    {
        switch (selection.selectionList.Count)
        {
            case 1:
                SelectObjectList[0].transform.position = select.newPos[0].SetPos[0];
                break;
            case 2:
                for(int i = 0; i<SelectObjectList.Count; i++)
                {
                    SelectObjectList[i].transform.position = select.newPos[1].SetPos[i];
                }
                break;
            case 3:
                for (int i = 0; i < SelectObjectList.Count; i++)
                {
                    SelectObjectList[i].transform.position = select.newPos[2].SetPos[i];
                }
                break;
            case 4:
                for (int i = 0; i < SelectObjectList.Count; i++)
                {
                    SelectObjectList[i].transform.position = select.newPos[3].SetPos[i];
                }
                break;
        }
    }
}
