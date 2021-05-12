using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.SimpleLocalization { 
public class PS_Trails : MonoBehaviour
{
    public Text buttonText;
    public MenuData.ShopsData.TRAILS trails;
    public MenuData.ShopsData.Prices price;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
        if (MenuData.Instance.shopsData.openTrails.Contains(trails))
        {
            if ((int)PlayerData.Instance.playerContent.Trails == (int)trails)
            {
                buttonText.text = LocalizationManager.Localize("Shop.Selected");
                PlayerData.Instance.trailsSelectedText = buttonText;
            }
            else
            {
                buttonText.text = LocalizationManager.Localize("Shop.Select");
            }
        }
        else
        {
            buttonText.text = ((int)price).ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(trails);
        if (MenuData.Instance.shopsData.openTrails.Contains(trails))
        {
            MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.SetActive(false);

            PlayerData.Instance.playerContent.Trails = trails;

            PlayerData.Instance.trailsSelectedText.text = LocalizationManager.Localize("Shop.Select");
            PlayerData.Instance.trailsSelectedText = buttonText;
            buttonText.text = LocalizationManager.Localize("Shop.Selected");

            PlayerData.Instance.SaveData();
        }
        else
        {
            //int price =  MenuData.Instance.shopsData.pricesTrails[(int)trails];
            if ((int)price <= CountData.Instance.amountData.coins) {
            MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.GetComponentInChildren<Text>().text=LocalizationManager.Localize("Shop.Bue");
             MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.GetComponent<Button>().interactable = true;
            MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton;
            buy.trails = trails;
            buy.buttonText = buttonText;
            buy.price = (int)price;
            }
            else {
                MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.GetComponentInChildren<Text>().text=LocalizationManager.Localize("Shop.NotMoney");
                MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.SetActive(true);
                MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.GetComponent<Button>().interactable = false;
            }

            


        }

    }
}
}