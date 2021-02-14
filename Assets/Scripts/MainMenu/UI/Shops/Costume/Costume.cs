using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Costume : MonoBehaviour
{
    public Text buttonText;
    public MenuData.ShopsData.COSTUME costume;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
        if (MainMenuManager.menuData.shopsData.openCostumes.Contains(costume))
        {
            if ((int)MainMenuManager.playerData.playerContent.costume == (int)costume)
            {
                buttonText.text = "Selected";
                MainMenuManager.playerData.costumeSelectedText = buttonText;
            }
            else
            {
                buttonText.text = "Select";
            }
        }
        else
        {
            buttonText.text = MainMenuManager.menuData.shopsData.pricesCostume[(int)costume].ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(costume);
        if (MainMenuManager.menuData.shopsData.openCostumes.Contains(costume))
        {
            MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(false);

            MainMenuManager.playerData.playerContent.costume = costume;

            MainMenuManager.playerData.costumeSelectedText.text = "Select";
            MainMenuManager.playerData.costumeSelectedText = buttonText;
            buttonText.text = "Selected";

            MainMenuManager.playerData.SaveData();
        }
        else
        {
            int price =  MainMenuManager.menuData.shopsData.pricesTrails[(int)costume];
            if (price <= MainMenuManager.countData.amountData.coins) {
            MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponentInChildren<Text>().text="Buy";
            MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponent<Button>().interactable = true;
            MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.buyCostumeButton;
            buy.costume = costume;
            buy.buttonText = buttonText;
            }
             else {
                MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponentInChildren<Text>().text="Not enough money";
                MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(true);
                MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponent<Button>().interactable = false;
            }
            


        }

    }
}

