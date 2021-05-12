using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCostumeButton : MonoBehaviour
{
    public MenuData.ShopsData.COSTUME costume;
    public MenuData.ShopsData.Prices price;
    public Text buttonText;
    //private int price;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>CostumeTap());
        //price =  MenuData.Instance.shopsData.pricesCostume[(int)costume];
    }

    public void CostumeTap(){
        if ((int)price <= CountData.Instance.amountData.coins){
            MenuData.Instance.shopsData.openCostumes.Add(costume);
            PlayerData.Instance.playerContent.Costume = costume;
            
            PlayerData.Instance.costumeSelectedText.text =  Assets.SimpleLocalization.LocalizationManager.Localize("Shop.Select");
            PlayerData.Instance.costumeSelectedText = buttonText;
            buttonText.text = Assets.SimpleLocalization.LocalizationManager.Localize("Shop.Selected");

            CountData.Instance.amountData.coins -= (int)price;
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
