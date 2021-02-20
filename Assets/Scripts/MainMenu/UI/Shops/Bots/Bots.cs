using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization { 
public class Bots : MonoBehaviour
{
    
    public Text buttonText;
    public MenuData.ShopsData.BOTS bots;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
        if (MenuData.Instance.shopsData.openBots.Contains(bots))
        {
            if ((int)PlayerData.Instance.playerContent.Bots == (int)bots)
            {
                buttonText.text = LocalizationManager.Localize("Shop.Selected");
                PlayerData.Instance.botSelectedText = buttonText;
            }
            else
            {
                buttonText.text = LocalizationManager.Localize("Shop.Select");
            }
        }
        else
        {
            buttonText.text = MenuData.Instance.shopsData.pricesBots[(int)bots].ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(bots);
        if (MenuData.Instance.shopsData.openBots.Contains(bots))
        {
            MainMenuManager.uiMainMenuManager.buyBotsButton.SetActive(false);

            PlayerData.Instance.playerContent.Bots = bots;

            PlayerData.Instance.botSelectedText.text = LocalizationManager.Localize("Shop.Select");
            PlayerData.Instance.botSelectedText = buttonText;
            buttonText.text = LocalizationManager.Localize("Shop.Selected");

            PlayerData.Instance.SaveData();
        }
        else
        {
            int price =  MenuData.Instance.shopsData.pricesTrails[(int)bots];
            if (price <= CountData.Instance.amountData.coins) {
            MainMenuManager.uiMainMenuManager.buyBotsButton.GetComponentInChildren<Text>().text=LocalizationManager.Localize("Shop.Bue");
            MainMenuManager.uiMainMenuManager.buyBotsButton.GetComponent<Button>().interactable = true;
            MainMenuManager.uiMainMenuManager.buyBotsButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.buyBotsButton;
            buy.bots = bots;
            buy.buttonText = buttonText;
            }
             else {
                MainMenuManager.uiMainMenuManager.buyBotsButton.GetComponentInChildren<Text>().text=LocalizationManager.Localize("Shop.NotMoney");
                MainMenuManager.uiMainMenuManager.buyBotsButton.SetActive(true);
                MainMenuManager.uiMainMenuManager.buyBotsButton.GetComponent<Button>().interactable = false;
            }



        }

    }
}
}
