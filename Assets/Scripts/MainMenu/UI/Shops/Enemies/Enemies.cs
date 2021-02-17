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
        if (MenuData.Instance.shopsData.openEnemyies.Contains(enemies))
        {
            if ((int)PlayerData.Instance.playerContent.enemyies == (int)enemies)
            {
                buttonText.text = "Selected";
                PlayerData.Instance.enemiesSelectedText = buttonText;
            }
            else
            {
                buttonText.text = "Select";
            }
        }
        else
        {
            print((int)enemies);
            buttonText.text = MenuData.Instance.shopsData.pricesEnemyies[(int)enemies].ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(enemies);
        if (MenuData.Instance.shopsData.openEnemyies.Contains(enemies))
        {
            MainMenuManager.uiMainMenuManager.buyEnemiesButton.SetActive(false);

            PlayerData.Instance.playerContent.enemyies = enemies;

            PlayerData.Instance.enemiesSelectedText.text = "Select";
            PlayerData.Instance.enemiesSelectedText = buttonText;
            buttonText.text = "Selected";

            PlayerData.Instance.SaveData();
        }
        else
        {
            int price =  MenuData.Instance.shopsData.pricesTrails[(int)enemies];
            if (price <= CountData.Instance.amountData.coins) {
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
