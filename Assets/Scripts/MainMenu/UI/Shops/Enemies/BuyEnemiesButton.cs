using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyEnemiesButton : MonoBehaviour
{
   public MenuData.ShopsData.ENEMYIES enemies;
    public Text buttonText;
    private int price;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>EnemiesTap());
        price =  MainMenuManager.menuData.shopsData.pricesEnemyies[(int)enemies];
    }

    public void EnemiesTap(){
        if (price <= MainMenuManager.countData.amountData.coins){
            MainMenuManager.menuData.shopsData.openEnemyies.Add(enemies);
            MainMenuManager.playerData.playerContent.enemyies = enemies;
            
            MainMenuManager.playerData.enemiesSelectedText.text = "Select";
            MainMenuManager.playerData.enemiesSelectedText = buttonText;
            buttonText.text = "Selected";

            MainMenuManager.countData.amountData.coins -= price;
            MainMenuManager.uiMainMenuManager.coins.GetComponentInChildren<ParticleSystem>().Play();
            MainMenuManager.uiMainMenuManager.coins.text = MainMenuManager.countData.amountData.coins.ToString();
            MainMenuManager.uiMainMenuManager.coins.GetComponent<AudioSource>().Play();

            MainMenuManager.playerData.SaveData();
            MainMenuManager.menuData.SaveData();
            MainMenuManager.countData.SaveData();

            gameObject.SetActive(false);
        }
    }
    public void SetActive(bool b){
        gameObject.SetActive(b);
    }
}
