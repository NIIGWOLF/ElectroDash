using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.SimpleLocalization
{
    public class LocalizationSwitcher : MonoBehaviour
    {
        public void Awake()
        {
            LocalizationManager.Read();
            if (SettingsData.Instance.configurationData.language.Equals(""))
            switch (Application.systemLanguage)
            {
                //case SystemLanguage.German:
                   // LocalizationManager.Language = "German";
                    //break;
                case SystemLanguage.Russian:
                    LocalizationManager.Language = "Russian";
                    SettingsData.Instance.configurationData.language = "Russian";
                    break;
                default:
                    LocalizationManager.Language = "English";
                    SettingsData.Instance.configurationData.language = "English";
                    break;
            }
            else{
                LocalizationManager.Language = SettingsData.Instance.configurationData.language;
            }
        }
        

        /// <summary>
        /// Change localization at runtime
        /// </summary>
        public void SetLocalization(string localization)
        {
            LocalizationManager.Language = localization;
            SettingsData.Instance.configurationData.language = localization;
            SettingsData.Instance.SaveData();
        }
    }
}
