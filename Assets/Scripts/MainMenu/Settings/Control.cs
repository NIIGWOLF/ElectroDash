using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    void Start(){
         
            Assets.SimpleLocalization.LocalizationManager.LocalizationChanged += Localize;
        print(SettingsData.Instance.configurationData.controlType);
        if (SettingsData.Instance.configurationData.controlType == ("Swipe")){
            
             string buttonText = Assets.SimpleLocalization.LocalizationManager.Localize("Settings.Swipe");
            gameObject.GetComponentInChildren<Text>().text = buttonText;
          
        }
        else if (SettingsData.Instance.configurationData.controlType == ("Arrows")){
           
              string buttonText = Assets.SimpleLocalization.LocalizationManager.Localize("Settings.Arrows");
            gameObject.GetComponentInChildren<Text>().text = buttonText;
           
        }
    }
    public void controlTap()
    {
       
        if (SettingsData.Instance.configurationData.controlType.Equals("Swipe")){
            SettingsData.Instance.configurationData.controlType = "Arrows";
            SettingsData.Instance.SaveData();
            string buttonText = Assets.SimpleLocalization.LocalizationManager.Localize("Settings.Arrows");
            gameObject.GetComponentInChildren<Text>().text = buttonText;
        }
        else if (SettingsData.Instance.configurationData.controlType.Equals("Arrows")){
            SettingsData.Instance.configurationData.controlType = "Swipe";
            SettingsData.Instance.SaveData();
            string buttonText = Assets.SimpleLocalization.LocalizationManager.Localize("Settings.Swipe");
            gameObject.GetComponentInChildren<Text>().text = buttonText;
        }
    }
     private void Localize()
        {

            gameObject.GetComponentInChildren<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("Settings."+SettingsData.Instance.configurationData.controlType);
        }
        public void OnDestroy()
        {
            Assets.SimpleLocalization.LocalizationManager.LocalizationChanged -= Localize;
        }
}
