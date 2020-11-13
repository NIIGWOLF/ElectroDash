using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCostumeButton : MonoBehaviour
{
    public MenuData.ShopsData.COSTUME costume;
    public Text buttonText;
    private int price;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>CostumeTap());
        price =  MainMenuManager.menuData.shopsData.pricesCostume[(int)costume];
    }

    public void CostumeTap(){
        if (price <= MainMenuManager.countData.amountData.coins){
            MainMenuManager.menuData.shopsData.openCostumes.Add(costume);
            MainMenuManager.playerData.playerContent.costume = costume;
            
            MainMenuManager.playerData.costumeSelectedText.text = "Select";
            MainMenuManager.playerData.costumeSelectedText = buttonText;
            buttonText.text = "Selected";

            MainMenuManager.countData.amountData.coins -= price;
            MainMenuManager.uiMainMenuManager.coins.text = MainMenuManager.countData.amountData.coins.ToString();


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
