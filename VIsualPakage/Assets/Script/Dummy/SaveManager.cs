using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private Camera camera1;
    [SerializeField]
    private Image[] saveButton;

    private SaveData saveData;

    public int value = 0;
    public string folderName = "";

    private void Start()
    {
        saveData = GetComponent<SaveData>();

        int value = 0;
        List<string> files = new List<string>();
        var emptyLis = new List<string>();
        List<bool> checkFile = new List<bool>();

        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/");
        foreach (DirectoryInfo subdir in dir.GetDirectories())
        {
            FileInfo[] fi = subdir.GetFiles("*.png");

            if (fi.Length == 0)
            {
                checkFile.Add(false);
                files.Add(null); ;
                Debug.Log(files.Count);
            }
            else
            {
                checkFile.Add(true);
                files.AddRange(subdir.GetFiles("*.png").Select(x => x.FullName).ToArray());
            }
        }

        for (int i = 0; i < files.Count + value; i++)
        {
            if (checkFile[i] == true)
            {
                saveButton[i].gameObject.SetActive(true);
                saveButton[i].sprite = LoadSprite(files[i]);
            }

        }
    }

    public void Levale(int value1)
    {
        value = value1;
        saveButton[value].gameObject.SetActive(true);
        name = value.ToString();

        if (saveData.SaveMode == true)
        {
            StartCoroutine("ScreenShot");
        }
    }

    IEnumerator ScreenShot()
    {
        yield return new WaitForEndOfFrame();
        ScreenShotClick();
    }

    public void ScreenShotClick()
    {
        RenderTexture renderTexture = camera1.targetTexture;
        SaveTexture(renderTexture, name);
    }

    public Sprite LoadSprite(string path)
    {
        byte[] fileData;

        if (File.Exists(path))
        {
            fileData = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            return Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        return null;
    }

    public void SaveTexture(RenderTexture rt, string name)
    {
        folderName = "";
        folderName = value.ToString();
        Directory.CreateDirectory("Assets/Resources/" + folderName);

        string path = "Assets/Resources/" + folderName + "/" + name + ".png";
        string Depath = "Assets/Resources/" + folderName + "/";

        DirectoryInfo directory = new DirectoryInfo(Depath);
        foreach (var file in directory.GetFiles())
        {
            file.Delete();
        }

        RenderTexture.active = rt;
        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        saveButton[value].sprite = sprite;
        RenderTexture.active = null;

        byte[] bytes;
        bytes = tex.EncodeToPNG();





        System.IO.File.WriteAllBytes(path, bytes);
    }
}
