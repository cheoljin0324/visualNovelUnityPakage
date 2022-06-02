using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDataFlow : MonoBehaviour
{
    TextDataSet textData;
    bool selectIn = false;
    bool instButton = true;

    private void Awake()
    {
        textData = GetComponent<TextDataSet>();
    }
    public bool SetNext()
    {
        if (instButton == true)
        {
            for (int i = 0; i < textData.dataSet.selectionList.Count; i++)
            {
                textData.obEle.Element();
            }
            textData.DataSet();
            textData.obEle.ButtonPosSet();
            instButton = false;
        }
       

        return selectIn;
    }
}
