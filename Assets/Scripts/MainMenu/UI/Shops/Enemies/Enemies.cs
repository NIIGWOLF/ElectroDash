using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    public Text buttonText;
    public MenuData.ShopsData.ENEMYIES enemies;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
        if (MainMenuManager.menuData.shopsData.openEnemyies.Contains(enemies))
        {
            if ((int)MainMenuManager.playerData.playerContent.enemyies == (int)enemies)
            {
                buttonText.text = "Selected";
                MainMenuManager.playerData.enemiesSelectedText = buttonText;
            }
            else
            {
                buttonText.text = "Select";
            }
        }
        else
        {
            print((int)enemies);
            buttonText.text = MainMenuManager.menuData.shopsData.pricesEnemyies[(int)enemies].ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(enemies);
        if (MainMenuManager.menuData.shopsData.openEnemyies.Contains(enemies))
        {
            MainMenuManager.uiMainMenuManager.buyEnemiesButton.SetActive(false);

            MainMenuManager.playerData.playerContent.enemyies = enemies;

            MainMenuManager.playerData.enemiesSelectedText.text = "Select";
            MainMenuManager.playerData.enemiesSelectedText = buttonText;
            buttonText.text = "Selected";

            MainMenuManager.playerData.SaveData();
        }
        else
        {
            int price =  MainMenuManager.menuData.shopsData.pricesTrails[(int)enemies];
            if (price <= MainMenuManager.countData.amountData.coins) {
            MainMenuManager.uiMainMenuManager.buyEnemiesButton.GetComponentInChildren<Text>().text="Buy";
            MainMenuManager.uiMainMenuManager.buyEnemiesButton.GetComponent<Button>().interactable = true;
            MainMenuManager.uiMainMenuManager.buyEnemiesButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.buyEnemiesButton;
            buy.enemies = enemies;
            buy.buttonText = buttonText;
            }
            else {
                MainMenuManager.uiMainMenuManager.buyEnemiesButton.GetComponentInChildren<Text>().text="Not enough money";
                MainMenuManager.uiMainMenuManager.buyEnemiesButton.SetActive(true);
                MainMenuManager.uiMainMenuManager.buyEnemiesButton.GetComponent<Button>().interactable = false;
            }



        }

    }
}
