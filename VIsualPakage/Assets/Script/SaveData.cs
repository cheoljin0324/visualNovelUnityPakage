using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    SaveManager saveManager;

    public bool SaveMode = false;

    public void Start()
    {
        saveManager = GetComponent<SaveManager>();
        Debug.Log(Application.dataPath);
    }

    public void SetSaveMode()
    {
        if (SaveMode == false)
        {
            SaveMode = true;
        }
        else
        {
            SaveMode = false;
        }
    }

    public void InButton()
    {
        if (SaveMode == true)
        {
            SaveInData();
        }
        else
        {
            LoadOutData();
        }
    }

    void SaveInData()
    {
        FileInfo info =new FileInfo(Application.dataPath + "/" + saveManager.value.ToString() + "File.txt");
        if (info.Exists)
        {
            File.Delete(Application.dataPath + "/" + saveManager.value.ToString() + "File.txt");
        }
        string JsonData = JsonUtility.ToJson(playerData);
        string path = Application.dataPath + "/" + saveManager.value.ToString() + "File.txt";
        File.WriteAllText(path, JsonData);
        Debug.Log(path);
    }

    void LoadOutData()
    {
        string path = Application.dataPath+"/"+saveManager.value.ToString()+ "File.txt";
        string JsonData = File.ReadAllText(path);
        Debug.Log(path);
        playerData=JsonUtility.FromJson<PlayerData>(JsonData);
        Debug.Log("LoadData");

    }

}
