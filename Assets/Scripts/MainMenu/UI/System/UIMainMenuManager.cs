using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuManager : MonoBehaviour
{
    public GameObject Character; //preview 
    public Text coins;
    public BuyCostumeButton buyCostumeButton;
    public Dictionary<string, GameObject> costumePrefabs;
    public Dictionary<string, GameObject> trailsPrefabs;
    public Dictionary<string, GameObject> enemyPrefabs;
    public Dictionary<string, GameObject> botPrefabs;
     void Awake(){
        costumePrefabs = new Dictionary<string, GameObject>(); //создаем словарь costume, с помощью имени можем получить префаб
        foreach (GameObject costume in Resources.LoadAll("Shops/Costume")) //выгружаем в него все из ресурсов из папки costume
        {
            costumePrefabs.Add(costume.name, costume);
        }
    }
    void Start(){
        coins.text = MainMenuManager.countData.amountData.coins.ToString();
    }
}
