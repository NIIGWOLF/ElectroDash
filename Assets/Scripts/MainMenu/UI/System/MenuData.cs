using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuData : MonoBehaviour
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
        {
            Classic = 0,
            Blue = 1,
            Rose = 2,
        }
        public List<COSTUME> openCostumes = new List<COSTUME>(){COSTUME.Classic};
        public List<int> pricesCostume = new List<int>(){0,1,1};

        // Eyes data
        public List<COSTUME> openEyes = new List<COSTUME>(){COSTUME.Classic};

        // Trails data
        public List<TRAILS> openTrails = new List<TRAILS>(){TRAILS.Classic};
        public List<int> pricesTrails = new List<int>(){0,1,1};
        public enum TRAILS
        {
            Classic = 0,
            Blue = 1,
            Rose = 2,
        }

        // Enemyies data
        public List<ENEMYIES> openEnemyies = new List<ENEMYIES>(){ENEMYIES.Classic};
        public List<int> pricesEnemyies = new List<int>(){0,1,1};
        public enum ENEMYIES
        {
            Classic = 0,
            Glamur = 1,
            Tarakan = 2,
        }

        // Bots data
        public List<BOTS> openBots = new List<BOTS>(){BOTS.Classic};
        public List<int> pricesBots = new List<int>(){0,1,1};
        public enum BOTS
        {
            Classic = 0,
            Blue = 1,
            Rose = 2,
        }

    }
}
