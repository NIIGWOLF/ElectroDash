using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuManager : MonoBehaviour
{
    public GameObject Character; //preview 
    public GameObject Enemy; 
    public GameObject Bot;
    public Text coins;
    public BuyCostumeButton buyCostumeButton;
    public BuyPs_TrailsButton BuyPs_TrailsButton;
    public BuyEnemiesButton buyEnemiesButton;
    public BuyBotsButton buyBotsButton;
    public Dictionary<string, GameObject> costumePrefabs;
    public Dictionary<string, GameObject> eyesPrefabs;
     public Dictionary<string, GameObject> psPrefabs;
    public Dictionary<string, GameObject> trailsPrefabs;
    public Dictionary<string, GameObject> enemyPrefabs;
    public Dictionary<string, GameObject> botPrefabs;
     void Awake(){
        costumePrefabs = new Dictionary<string, GameObject>(); //создаем словарь costume, с помощью имени можем получить префаб
        foreach (GameObject costume in Resources.LoadAll("Shops/Costume")) //выгружаем в него все из ресурсов из папки costume
        {
            costumePrefabs.Add(costume.name, costume);
        }

        eyesPrefabs = new Dictionary<string, GameObject>();
        foreach (GameObject eyes in Resources.LoadAll("Shops/Eyes"))
        {
            eyesPrefabs.Add(eyes.name, eyes);
        }

        psPrefabs = new Dictionary<string, GameObject>();
        foreach (GameObject ps in Resources.LoadAll("Shops/ParticleSystem"))
        {
            psPrefabs.Add(ps.name, ps);
        }

        trailsPrefabs = new Dictionary<string, GameObject>();
        foreach (GameObject trail in Resources.LoadAll("Shops/Trails"))
        {
            trailsPrefabs.Add(trail.name, trail);
        }

        enemyPrefabs = new Dictionary<string, GameObject>();
        foreach (GameObject enemy in Resources.LoadAll("Shops/Enemy"))
        {
            enemyPrefabs.Add(enemy.name, enemy);
        }

        botPrefabs = new Dictionary<string, GameObject>();
        foreach (GameObject bot in Resources.LoadAll("Shops/Bot"))
        {
            botPrefabs.Add(bot.name, bot);
        }
        
    }
    void Start(){
        coins.text = MainMenuManager.countData.amountData.coins.ToString();
    }
}
