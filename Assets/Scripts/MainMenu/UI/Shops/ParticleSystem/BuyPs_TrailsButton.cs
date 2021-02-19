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
        price =  MenuData.Instance.shopsData.pricesTrails[(int)trails];
    }

    public void TrailsTap(){
        if (price <= CountData.Instance.amountData.coins){
            MenuData.Instance.shopsData.openTrails.Add(trails);
            PlayerData.Instance.playerContent.trails = trails;
            
            PlayerData.Instance.trailsSelectedText.text = Assets.SimpleLocalization.LocalizationManager.Localize("Shop.Select");
            PlayerData.Instance.trailsSelectedText = buttonText;
            buttonText.text = Assets.SimpleLocalization.LocalizationManager.Localize("Shop.Selected");

            CountData.Instance.amountData.coins -= price;
            MainMenuManager.uiMainMenuManager.coins.GetComponentInChildren<ParticleSystem>().Play();
            MainMenuManager.uiMainMenuManager.coins.text = CountData.Instance.amountData.coins.ToString();
            

            PlayerData.Instance.SaveData();
            MenuData.Instance.SaveData();
            CountData.Instance.SaveData();

            gameObject.SetActive(false);
        }
    }
    public void SetActive(bool b){
        gameObject.SetActive(b);
    }
}
