using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.SimpleLocalization
{
    public class Costume : MonoBehaviour
    {
        public Text buttonText;
        public MenuData.ShopsData.COSTUME costume;
        public MenuData.ShopsData.Prices price;
        void Start()
        {
            LocalizationManager.LocalizationChanged += Localize;
            gameObject.GetComponent<Button>().onClick.AddListener(() => ChangePreview());
            if (MenuData.Instance.shopsData.openCostumes.Contains(costume))
            {
                if ((int)PlayerData.Instance.playerContent.Costume == (int)costume)
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
                buttonText.text = ((int)price).ToString();
            }
        }
        private void ChangePreview()
        {
            MainMenuManager.makePlayer.Player(costume);
            if (MenuData.Instance.shopsData.openCostumes.Contains(costume))
            {
                MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(false);

                PlayerData.Instance.playerContent.Costume = costume;

                PlayerData.Instance.costumeSelectedText.text = LocalizationManager.Localize("Shop.Select");
                PlayerData.Instance.costumeSelectedText = buttonText;
                buttonText.text = LocalizationManager.Localize("Shop.Selected");

                PlayerData.Instance.SaveData();
            }
            else
            {

                //nt price =  MenuData.Instance.shopsData.pricesTrails[(int)costume];
                //int price =  MenuData.Instance.shopsData.pricesCostume[(int)costume];

                if ((int)price <= CountData.Instance.amountData.coins)
                {
                    MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponentInChildren<Text>().text = LocalizationManager.Localize("Shop.Bue");
                    MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponent<Button>().interactable = true;
                    MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(true);
                    var buy = MainMenuManager.uiMainMenuManager.buyCostumeButton;
                    buy.costume = costume;
                    buy.buttonText = buttonText;
                    buy.price = price;
                }
                else
                {
                    MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponentInChildren<Text>().text = LocalizationManager.Localize("Shop.NotMoney");
                    MainMenuManager.uiMainMenuManager.buyCostumeButton.SetActive(true);
                    MainMenuManager.uiMainMenuManager.buyCostumeButton.GetComponent<Button>().interactable = false;
                }



            }

        }

        private void Localize()
        {
            if (MenuData.Instance.shopsData.openCostumes.Contains(costume))
            {
                if ((int)PlayerData.Instance.playerContent.Costume == (int)costume)
                {
                    buttonText.text = LocalizationManager.Localize("Shop.Selected");
                    PlayerData.Instance.costumeSelectedText = buttonText;
                }
                else
                {
                    buttonText.text = LocalizationManager.Localize("Shop.Select");
                }
            }
        }
        public void OnDestroy()
        {
            LocalizationManager.LocalizationChanged -= Localize;
        }
    }
}
