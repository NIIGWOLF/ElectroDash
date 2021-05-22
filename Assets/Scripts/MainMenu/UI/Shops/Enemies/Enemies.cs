﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.SimpleLocalization
{
    public class Enemies : MonoBehaviour
    {
        public Text buttonText;
        public MenuData.ShopsData.ENEMYIES enemies;
        public MenuData.ShopsData.Prices price;
        void Start()
        {
            LocalizationManager.LocalizationChanged += Localize;
            gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
            if (MenuData.Instance.shopsData.openEnemyies.Contains(enemies))
            {
                if ((int)PlayerData.Instance.playerContent.Enemyies == (int)enemies)
                {
                    buttonText.text = LocalizationManager.Localize("Shop.Selected");
                    PlayerData.Instance.enemiesSelectedText = buttonText;
                }
                else
                {
                    buttonText.text = LocalizationManager.Localize("Shop.Select");
                }
            }
            else
            {
                print((int)enemies);
                buttonText.text = ((int)price).ToString();
            }
        }
        private void ChangePreview()
        {
            MainMenuManager.makePlayer.Player(enemies);
            if (MenuData.Instance.shopsData.openEnemyies.Contains(enemies))
            {
                MainMenuManager.uiMainMenuManager.buyEnemiesButton.SetActive(false);

                PlayerData.Instance.playerContent.Enemyies = enemies;

                PlayerData.Instance.enemiesSelectedText.text = LocalizationManager.Localize("Shop.Select");
                PlayerData.Instance.enemiesSelectedText = buttonText;
                buttonText.text = LocalizationManager.Localize("Shop.Selected");

                PlayerData.Instance.SaveData();
            }
            else
            {
                //int price =  MenuData.Instance.shopsData.pricesEnemyies[(int)enemies];
                if ((int)price <= CountData.Instance.amountData.coins)
                {
                    MainMenuManager.uiMainMenuManager.buyEnemiesButton.GetComponentInChildren<Text>().text = LocalizationManager.Localize("Shop.Bue");
                    MainMenuManager.uiMainMenuManager.buyEnemiesButton.GetComponent<Button>().interactable = true;
                    MainMenuManager.uiMainMenuManager.buyEnemiesButton.SetActive(true);
                    var buy = MainMenuManager.uiMainMenuManager.buyEnemiesButton;
                    buy.enemies = enemies;
                    buy.buttonText = buttonText;
                    buy.price = (int)price;
                }
                else
                {
                    MainMenuManager.uiMainMenuManager.buyEnemiesButton.GetComponentInChildren<Text>().text = LocalizationManager.Localize("Shop.NotMoney");
                    MainMenuManager.uiMainMenuManager.buyEnemiesButton.SetActive(true);
                    MainMenuManager.uiMainMenuManager.buyEnemiesButton.GetComponent<Button>().interactable = false;
                }



            }

        }

        private void Localize()
        {
            if (MenuData.Instance.shopsData.openEnemyies.Contains(enemies))
            {
                if ((int)PlayerData.Instance.playerContent.Enemyies == (int)enemies)
                {
                    buttonText.text = LocalizationManager.Localize("Shop.Selected");
                    PlayerData.Instance.enemiesSelectedText = buttonText;
                }
                else
                {
                    buttonText.text = LocalizationManager.Localize("Shop.Select");
                }
            }
        }
        public void OnDestroy()
        {
            LocalizationManager.LocalizationChanged -= Localize;
        }
    }
}