using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class AudioData : MonoBehaviour
{
    public Audio audio;
     public void Awake()
    {
        LoadData();
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(audio);
        File.WriteAllText(Application.persistentDataPath + "/Data/MainMenuData/AudioData.json", json);
    }
    public void LoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data/MainMenuData/AudioData.json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/MainMenuData");
            audio = new Audio();
            SaveData();

        }
        else
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/Data/MainMenuData/AudioData.json");
            audio = JsonUtility.FromJson<Audio>(json);
            Debug.Log(Application.persistentDataPath);
        }
    }
    public class Audio{
        float musicVolume = 1;
        float soundsVolume = 1;
    }
}
