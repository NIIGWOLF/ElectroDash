using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CountData : Singleton<CountData>
{
    public AmountData amountData;
    public void Awake(){
        LoadData();
    }
    public void SaveData(){
        string json = JsonUtility.ToJson(amountData);
        File.WriteAllText(Application.persistentDataPath + "/Data/MainMenuData/amountData.json", json);
    }
    public void LoadData(){
        if (!File.Exists(Application.persistentDataPath + "/Data/MainMenuData/amountData.json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/MainMenuData");
            amountData = new AmountData();
            SaveData();
            
        }
        else
        {
            string json = File.ReadAllText(Application.persistentDataPath +"/Data/MainMenuData/amountData.json");
            amountData = JsonUtility.FromJson<AmountData>(json);
            Debug.Log(Application.persistentDataPath);
        }
    }

    public class AmountData{
        public int coins = 1000;
    }
       
}
