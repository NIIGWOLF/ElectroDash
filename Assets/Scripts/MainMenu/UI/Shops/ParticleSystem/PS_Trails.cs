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
        if (MainMenuManager.menuData.shopsData.openTrails.Contains(trails))
        {
            if ((int)MainMenuManager.playerData.playerContent.trails == (int)trails)
            {
                buttonText.text = "Selected";
                MainMenuManager.playerData.trailsSelectedText = buttonText;
            }
            else
            {
                buttonText.text = "Select";
            }
        }
        else
        {
            buttonText.text = MainMenuManager.menuData.shopsData.pricesTrails[(int)trails].ToString();
        }
    }
    private void ChangePreview()
    {
        MainMenuManager.makePlayer.Player(trails);
        if (MainMenuManager.menuData.shopsData.openTrails.Contains(trails))
        {
            MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.SetActive(false);

            MainMenuManager.playerData.playerContent.trails = trails;

            MainMenuManager.playerData.trailsSelectedText.text = "Select";
            MainMenuManager.playerData.trailsSelectedText = buttonText;
            buttonText.text = "Selected";

            MainMenuManager.playerData.SaveData();
        }
        else
        {
            MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton.SetActive(true);
            var buy = MainMenuManager.uiMainMenuManager.BuyPs_TrailsButton;
            buy.trails = trails;
            buy.buttonText = buttonText;

            


        }

    }
}
