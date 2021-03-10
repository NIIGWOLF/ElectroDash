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
        { Classic = 0,
            Blue = 1,
            Rose = 2,
            Yellow = 3,
            Red = 4,
            Violet = 5,
            LightViolet = 6,
            GreenBlue = 7,
            GreenMetal = 8,
            Fire = 9,
            Transparent = 10,
            YEEE = 11,
            Pirat = 12,
            Ogr = 14,
            Simpson = 15,
            Gin = 16,
        }
        public List<COSTUME> openCostumes = new List<COSTUME>(){COSTUME.Classic};
        public List<int> pricesCostume = new List<int>(){0,1,1,1,2,2,2,3,3,3,3,4,4,4,4,4};

        // Eyes data
        public List<COSTUME> openEyes = new List<COSTUME>(){COSTUME.Classic};

        // Trails data
        public List<TRAILS> openTrails = new List<TRAILS>(){TRAILS.Classic};
        public List<int> pricesTrails = new List<int>(){0,1,1,1,2,2,2,3,3,3,4,4};
        public enum TRAILS
        {
            Classic = 0,
            Blue = 1,
            Rose = 2,
            Yellow = 3,
            Red = 4,
            Violet = 5,
            LightViolet = 6,
            GreenBlue = 7,
            Fire = 8,
            Transparent = 9,
            YEEE = 10,
            Pirat = 11,
        }

        // Enemyies data
        public List<ENEMYIES> openEnemyies = new List<ENEMYIES>(){ENEMYIES.Classic};
        public List<int> pricesEnemyies = new List<int>(){0,1,1,1,1,2,2,2,3,3,3,3,4,4,4,4,4,4};
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


        }

        // Bots data
        public List<BOTS> openBots = new List<BOTS>(){BOTS.Classic};
        public List<int> pricesBots = new List<int>(){0,1,1,1,1,2,2,2,3,3,3,3,4,4,4,4,4,4};
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

        }

    }
}
