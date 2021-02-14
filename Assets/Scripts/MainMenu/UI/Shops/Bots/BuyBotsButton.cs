using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyBotsButton : MonoBehaviour
{
     public MenuData.ShopsData.BOTS bots;
    public Text buttonText;
    private int price;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>BotsTap());
        price =  MainMenuManager.menuData.shopsData.pricesBots[(int)bots];
    }

    public void BotsTap(){
        if (price <= MainMenuManager.countData.amountData.coins){
            MainMenuManager.menuData.shopsData.openBots.Add(bots);
            MainMenuManager.playerData.playerContent.bots = bots;
            
            MainMenuManager.playerData.botSelectedText.text = "Select";
            MainMenuManager.playerData.botSelectedText = buttonText;
            buttonText.text = "Selected";

            MainMenuManager.countData.amountData.coins -= price;
            MainMenuManager.uiMainMenuManager.coins.GetComponentInChildren<ParticleSystem>().Play();
            MainMenuManager.uiMainMenuManager.coins.text = MainMenuManager.countData.amountData.coins.ToString();
            

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
