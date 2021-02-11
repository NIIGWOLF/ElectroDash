using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerData : Singleton<PlayerData>
{
    public PlayerContent playerContent;
    public Text costumeSelectedText;
    public Text trailsSelectedText;
    public Text enemiesSelectedText;
    public Text botSelectedText;
    public void Awake(){
        LoadData();
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(playerContent);
        File.WriteAllText(Application.persistentDataPath + "/Data/Player.json", json);
    }
    public void LoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data/Player.json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data");
            playerContent = new PlayerContent();
            SaveData();
        }
        else
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/Data/Player.json");
            playerContent = JsonUtility.FromJson<PlayerContent>(json);
        }
    }

    public class PlayerContent
    {
        public MenuData.ShopsData.COSTUME costume = MenuData.ShopsData.COSTUME.Classic;
        public MenuData.ShopsData.BOTS bots = MenuData.ShopsData.BOTS.Classic;
        public MenuData.ShopsData.ENEMYIES enemyies = MenuData.ShopsData.ENEMYIES.Classic;
        public MenuData.ShopsData.TRAILS trails = MenuData.ShopsData.TRAILS.Classic;
    }

}
