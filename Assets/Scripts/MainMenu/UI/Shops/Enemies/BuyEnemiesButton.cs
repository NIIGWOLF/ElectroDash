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
        price =  MenuData.Instance.shopsData.pricesEnemyies[(int)enemies];
    }

    public void EnemiesTap(){
        if (price <= CountData.Instance.amountData.coins){
            MenuData.Instance.shopsData.openEnemyies.Add(enemies);
            PlayerData.Instance.playerContent.enemyies = enemies;
            
            PlayerData.Instance.enemiesSelectedText.text = "Select";
            PlayerData.Instance.enemiesSelectedText = buttonText;
            buttonText.text = "Selected";

            CountData.Instance.amountData.coins -= price;
            MainMenuManager.uiMainMenuManager.coins.GetComponentInChildren<ParticleSystem>().Play();
            MainMenuManager.uiMainMenuManager.coins.text = CountData.Instance.amountData.coins.ToString();
            

            PlayerData.Instance.SaveData();
            MenuData.Instance.SaveData();
            CountData.Instance.SaveData();

            gameObject.SetActive(false);
        }
    }
    public void SetActive(bool b){
        gameObject.SetActive(b);
    }
}
