using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.SimpleLocalization { 
public class Costume : MonoBehaviour
{
    public Text buttonText;
    public MenuData.ShopsData.COSTUME costume;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
        if (MenuData.Instance.shopsData.openCostumes.Contains(costume))
        {
            if ((int)PlayerData.Instance.playerContent.costume == (int)costume)
            {
                buttonText.text = LocalizationManager.Localize("Shop.Selected");
                PlayerData.Instance.costumeSelectedText = buttonText;
            }
            else
            {
                buttonText.text = LocalizationManager.Localize("Shop.Select");
            }
        }
        else
        {
            buttonText.text = MenuData.Instance.shopsData.pricesCostume[(int)costume].ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(costume);
        if (MenuData.Instance.shopsData.openCostumes.Contains(costume))
        {
            MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(false);

            PlayerData.Instance.playerContent.costume = costume;

            PlayerData.Instance.costumeSelectedText.text = LocalizationManager.Localize("Shop.Select");
            PlayerData.Instance.costumeSelectedText = buttonText;
            buttonText.text = LocalizationManager.Localize("Shop.Selected");

            PlayerData.Instance.SaveData();
        }
        else
        {
            int price =  MenuData.Instance.shopsData.pricesTrails[(int)costume];
            if (price <= CountData.Instance.amountData.coins) {
            MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponentInChildren<Text>().text=LocalizationManager.Localize("Shop.Bue");
            MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponent<Button>().interactable = true;
            MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.buyCostumeButton;
            buy.costume = costume;
            buy.buttonText = buttonText;
            }
             else {
                MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponentInChildren<Text>().text=LocalizationManager.Localize("Shop.NotMoney");
                MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(true);
                MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponent<Button>().interactable = false;
            }
            


        }

    }
}
}
