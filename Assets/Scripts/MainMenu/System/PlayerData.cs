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
    
    public void Awake()
    {
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
        private MenuData.ShopsData.COSTUME costume = MenuData.ShopsData.COSTUME.Classic;
        private MenuData.ShopsData.BOTS bots = MenuData.ShopsData.BOTS.Classic;
        private MenuData.ShopsData.ENEMYIES enemyies = MenuData.ShopsData.ENEMYIES.Classic;
        private MenuData.ShopsData.TRAILS trails = MenuData.ShopsData.TRAILS.Classic;

        public MenuData.ShopsData.COSTUME Costume
        {
            get => costume;
            set
            {
                costume = value;
            }
        }
        public MenuData.ShopsData.BOTS Bots
        {
            get => bots;
            set
            {

                bots = value;
            }
        }
        public MenuData.ShopsData.ENEMYIES Enemyies
        {
            get => enemyies;
            set
            {
                enemyies = value;
            }
        }
        public MenuData.ShopsData.TRAILS Trails
        {
            get => trails;
            set
            {
                trails = value;
            }
        }
    }

}
