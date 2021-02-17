using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HintData : Singleton<HintData>
{
    public Hint hint;
    public void Awake()
    {
        LoadData();
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(hint);
        File.WriteAllText(Application.persistentDataPath + "/Data/MainMenuData/HintData.json", json);
    }
    public void LoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data/MainMenuData/HintData.json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/MainMenuData");
            hint = new Hint();
            SaveData();

        }
        else
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/Data/MainMenuData/HintData.json");
            hint = JsonUtility.FromJson<Hint>(json);
            Debug.Log(Application.persistentDataPath);
        }
    }

    public class Hint{
        public int simpleHint = 2;
        public int mapHint = 2;
    }
}
