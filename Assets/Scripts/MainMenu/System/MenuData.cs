using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuData : Singleton<MenuData>
{
    public ShopsData shopsData;
    public void Awake()
    {
        LoadData();
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(shopsData);
        File.WriteAllText(Application.persistentDataPath + "/Data/MainMenuData/ShopsData.json", json);
    }
    public void LoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data/MainMenuData/ShopsData.json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/MainMenuData");
            shopsData = new ShopsData();
            SaveData();

        }
        else
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/Data/MainMenuData/ShopsData.json");
            shopsData = JsonUtility.FromJson<ShopsData>(json);
            Debug.Log(Application.persistentDataPath);
        }
    }

    public class ShopsData
    {
        // Costume data
        public enum COSTUME
        {  Classic = 0,
            Blue = 1,
            Rose = 2,
            Yellow = 3,
            Red = 4,
            Metal = 5,
            Violet = 6,
            LightViolet = 7,
            GreenBlue = 8,
            GreenMetal = 9,
            Fire = 10,
            Heart = 11,
            Transparent = 12,
            YEEE = 13,
            Mustashe = 14,
            Pirat = 15,
            Ogr = 16,
            Simpson = 17,
            Anime = 18,
            Scelet = 19,
            Iden = 20,
            Gin = 21,
            KingStory = 22,
            Strawberry = 23,
        }
        public enum Prices{
            cheap = 4,
            low_cost = 7,
            medium = 10,
            expensive = 15,
            exclusive = 20,
            legendary = 30,
        }
        public List<COSTUME> openCostumes = new List<COSTUME>(){COSTUME.Classic};
       
        // Eyes data
        public List<COSTUME> openEyes = new List<COSTUME>(){COSTUME.Classic};

        // Trails data
        public List<TRAILS> openTrails = new List<TRAILS>(){TRAILS.Classic};
       
        public enum TRAILS
        {
           Classic = 0,
            Blue = 1,
            Rose = 2,
            Yellow = 3,
            Red = 4,
            Metal = 5,
            Violet = 6,
            LightViolet = 7,
            GreenBlue = 8,
            GreenMetal = 9,
            Fire = 10,
            Heart = 11,
            Transparent = 12,
            YEEE = 13,
            Mustashe = 14,
            Pirat = 15,
            Ogr = 16,
            Simpson = 17,
            Anime = 18,
            Scelet = 19,
            Iden = 20,
            Gin = 21,
            KingStory = 22,
            Strawberry = 23,
        }

        // Enemyies data
        public List<ENEMYIES> openEnemyies = new List<ENEMYIES>(){ENEMYIES.Classic};
       
        public enum ENEMYIES
        {
           Classic = 0,
            Orange = 1,
            Green = 2,
            Violet = 3,
            GreenWhite = 4,
            Yellow = 5,
            YellowRed = 6,
            Pink = 7,
            GreenMetal = 8,
            Fire = 9,
            Transparent = 10,
            Shark = 11,
            Pirat = 12,
            Ogr = 14,
            Simpson = 15,
            Iden = 16,
            Tree = 17,
            Anime = 18,
            Heart = 19,
            Metal = 20,
            Mustashe = 21,
            Scelet = 22,
            KingStory = 23,
            Apple = 24,

        }

        // Bots data
        public List<BOTS> openBots = new List<BOTS>(){BOTS.Classic};

        public enum BOTS
        {
            Classic = 0,
            Green = 1,
            Blue = 2,
            Rose = 3,
            Yellow = 4,
            Red = 5,
            Violet = 6,
            LightViolet = 7,
            GreenBlue = 8,
            GreenMetal = 9,
            Fire = 10,
            Transparent = 11,
            YEEE = 12,
            Pirat = 13,
            Ogr = 14,
            Simpson = 15,
            Iden = 16,
            Gin = 17,
            Anime = 18,
            Heart = 19,
            Mustashe = 20,
            Metal = 21,
            Scelet = 22,
             KingStory = 23,
            Blueberry = 24,

        }

    }
}
