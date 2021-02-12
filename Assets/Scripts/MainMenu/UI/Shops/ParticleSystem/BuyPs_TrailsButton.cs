using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPs_TrailsButton : MonoBehaviour
{
     public MenuData.ShopsData.TRAILS trails;
    public Text buttonText;
    private int price;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>TrailsTap());
        price =  MainMenuManager.menuData.shopsData.pricesTrails[(int)trails];
    }

    public void TrailsTap(){
        if (price <= MainMenuManager.countData.amountData.coins){
            MainMenuManager.menuData.shopsData.openTrails.Add(trails);
            MainMenuManager.playerData.playerContent.trails = trails;
            
            MainMenuManager.playerData.trailsSelectedText.text = "Select";
            MainMenuManager.playerData.trailsSelectedText = buttonText;
            buttonText.text = "Selected";

            MainMenuManager.countData.amountData.coins -= price;
            MainMenuManager.uiMainMenuManager.coins.GetComponentInChildren<ParticleSystem>().Play();
            MainMenuManager.uiMainMenuManager.coins.text = MainMenuManager.countData.amountData.coins.ToString();
            MainMenuManager.uiMainMenuManager.coins.GetComponent<AudioSource>().Play();

            MainMenuManager.playerData.SaveData();
            MainMenuManager.menuData.SaveData();
            MainMenuManager.countData.SaveData();

            gameObject.SetActive(false);
        }
    }
    public void SetActive(bool b){
        gameObject.SetActive(b);
    }
}
