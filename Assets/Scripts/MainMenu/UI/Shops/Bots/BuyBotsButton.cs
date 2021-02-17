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
        price =  MenuData.Instance.shopsData.pricesBots[(int)bots];
    }

    public void BotsTap(){
        if (price <= CountData.Instance.amountData.coins){
            MenuData.Instance.shopsData.openBots.Add(bots);
            PlayerData.Instance.playerContent.bots = bots;
            
            PlayerData.Instance.botSelectedText.text = "Select";
            PlayerData.Instance.botSelectedText = buttonText;
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
