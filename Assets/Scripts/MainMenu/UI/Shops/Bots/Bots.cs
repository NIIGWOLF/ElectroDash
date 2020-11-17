﻿using System.Collections;
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
        if (MainMenuManager.menuData.shopsData.openBots.Contains(bots))
        {
            if ((int)MainMenuManager.playerData.playerContent.bots == (int)bots)
            {
                buttonText.text = "Selected";
                MainMenuManager.playerData.botSelectedText = buttonText;
            }
            else
            {
                buttonText.text = "Select";
            }
        }
        else
        {
            buttonText.text = MainMenuManager.menuData.shopsData.pricesBots[(int)bots].ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(bots);
        if (MainMenuManager.menuData.shopsData.openBots.Contains(bots))
        {
            MainMenuManager.uiMainMenuManager.buyBotsButton.SetActive(false);

            MainMenuManager.playerData.playerContent.bots = bots;

            MainMenuManager.playerData.botSelectedText.text = "Select";
            MainMenuManager.playerData.botSelectedText = buttonText;
            buttonText.text = "Selected";

            MainMenuManager.playerData.SaveData();
        }
        else
        {
            MainMenuManager.uiMainMenuManager.buyBotsButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.buyBotsButton;
            buy.bots = bots;
            buy.buttonText = buttonText;




        }

    }
}
