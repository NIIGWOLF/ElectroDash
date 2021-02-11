using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class LevelData : Singleton<LevelData>
{
    // Start is called before the first frame update
   public LevelInfo levelInfo;
    public void Awake(){
        LoadData();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(levelInfo);
        File.WriteAllText(Application.persistentDataPath + "/Data/LevelData/LevelInfo.json", json);
    }
    public void LoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data/LevelData/LevelInfo.json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/LevelData");
            levelInfo = new LevelInfo();
            SaveData();

        }
        else
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/Data/LevelData/LevelInfo.json");
            levelInfo = JsonUtility.FromJson<LevelInfo>(json);
            Debug.Log(Application.persistentDataPath);
        }
    }

    public class LevelInfo{
        public int levelCount = 2;
        public int lastOpenLevel = 1;
        public List<string> levelActivStars = new List<string>(){"000","000","000"};
        public List<int> levelStars = new List<int>(){0,1,2};
    }
}
