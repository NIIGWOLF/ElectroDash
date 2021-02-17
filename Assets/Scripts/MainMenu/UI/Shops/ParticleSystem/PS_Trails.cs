using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PS_Trails : MonoBehaviour
{
    public Text buttonText;
    public MenuData.ShopsData.TRAILS trails;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
        if (MenuData.Instance.shopsData.openTrails.Contains(trails))
        {
            if ((int)PlayerData.Instance.playerContent.trails == (int)trails)
            {
                buttonText.text = "Selected";
                PlayerData.Instance.trailsSelectedText = buttonText;
            }
            else
            {
                buttonText.text = "Select";
            }
        }
        else
        {
            buttonText.text = MenuData.Instance.shopsData.pricesTrails[(int)trails].ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(trails);
        if (MenuData.Instance.shopsData.openTrails.Contains(trails))
        {
            MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.SetActive(false);

            PlayerData.Instance.playerContent.trails = trails;

            PlayerData.Instance.trailsSelectedText.text = "Select";
            PlayerData.Instance.trailsSelectedText = buttonText;
            buttonText.text = "Selected";

            PlayerData.Instance.SaveData();
        }
        else
        {
            int price =  MenuData.Instance.shopsData.pricesTrails[(int)trails];
            if (price <= CountData.Instance.amountData.coins) {
            MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.GetComponentInChildren<Text>().text="Buy";
             MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.GetComponent<Button>().interactable = true;
            MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton;
            buy.trails = trails;
            buy.buttonText = buttonText;
            }
            else {
                MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.GetComponentInChildren<Text>().text="Not enough money";
                MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.SetActive(true);
                MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.GetComponent<Button>().interactable = false;
            }

            


        }

    }
}
