using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyEnemiesButton : MonoBehaviour
{
   public MenuData.ShopsData.ENEMYIES enemies;
    public Text buttonText;
    public int price;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>EnemiesTap());
       
    }

    public void EnemiesTap(){
        if (price <= CountData.Instance.amountData.coins){
            MenuData.Instance.shopsData.openEnemyies.Add(enemies);
            PlayerData.Instance.playerContent.Enemyies = enemies;
            
            PlayerData.Instance.enemiesSelectedText.text =  Assets.SimpleLocalization.LocalizationManager.Localize("Shop.Select");
            PlayerData.Instance.enemiesSelectedText = buttonText;
            buttonText.text = Assets.SimpleLocalization.LocalizationManager.Localize("Shop.Selected");

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
