using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDataSet : MonoBehaviour
{
    public SelectionObjectElement obEle;
    public SelectionDataSetting dataSet;

    private void Awake()
    {
        obEle = GetComponent<SelectionObjectElement>();
        dataSet = GetComponent<SelectionDataSetting>();
    }

    public void DataSet()
    {
        for(int i = 0; i<obEle.SelectObjectList.Count; i++)
        {
            obEle.SelectObjectList[i].GetComponentInChildren<Text>().text = dataSet.selectionList[i];
        }
    }
}
