using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bots : MonoBehaviour
{
    
    public Text buttonText;
    public MenuData.ShopsData.BOTS bots;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
        if (MenuData.Instance.shopsData.openBots.Contains(bots))
        {
            if ((int)PlayerData.Instance.playerContent.bots == (int)bots)
            {
                buttonText.text = "Selected";
                PlayerData.Instance.botSelectedText = buttonText;
            }
            else
            {
                buttonText.text = "Select";
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

            PlayerData.Instance.playerContent.bots = bots;

            PlayerData.Instance.botSelectedText.text = "Select";
            PlayerData.Instance.botSelectedText = buttonText;
            buttonText.text = "Selected";

            PlayerData.Instance.SaveData();
        }
        else
        {
            int price =  MenuData.Instance.shopsData.pricesTrails[(int)bots];
            if (price <= CountData.Instance.amountData.coins) {
            MainMenuManager.uiMainMenuManager.buyBotsButton.GetComponentInChildren<Text>().text="Buy";
            MainMenuManager.uiMainMenuManager.buyBotsButton.GetComponent<Button>().interactable = true;
            MainMenuManager.uiMainMenuManager.buyBotsButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.buyBotsButton;
            buy.bots = bots;
            buy.buttonText = buttonText;
            }
             else {
                MainMenuManager.uiMainMenuManager.buyBotsButton.GetComponentInChildren<Text>().text="Not enough money";
                MainMenuManager.uiMainMenuManager.buyBotsButton.SetActive(true);
                MainMenuManager.uiMainMenuManager.buyBotsButton.GetComponent<Button>().interactable = false;
            }



        }

    }
}
