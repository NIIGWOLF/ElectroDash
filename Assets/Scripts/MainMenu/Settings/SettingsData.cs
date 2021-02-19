using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SettingsData : MonoBehaviour
{
    public ConfigurationData configurationData;
    public void Awake()
    {
        LoadData();
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(configurationData);
        File.WriteAllText(Application.persistentDataPath + "/Data/MainMenuData/SettingsData.json", json);
    }
    public void LoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data/MainMenuData/SettingsData.json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/MainMenuData");
            configurationData = new ConfigurationData();
            SaveData();

        }
        else
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/Data/MainMenuData/SettingsData.json");
            configurationData = JsonUtility.FromJson<ConfigurationData>(json);
            Debug.Log(Application.persistentDataPath);
        }
    }
    public class ConfigurationData {
        public string language = "English";
    }
}
