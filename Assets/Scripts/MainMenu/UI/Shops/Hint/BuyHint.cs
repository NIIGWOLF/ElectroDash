using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHint : MonoBehaviour
{
    public void BuySimpleHint(){
         MainMenuManager.hintData.hint.simpleHint++;
         MainMenuManager.hintData.SaveData();
         MainMenuManager.uiMainMenuManager.simpleHintCount.GetComponentInChildren<Text>().text = MainMenuManager.hintData.hint.simpleHint.ToString();
        
    }
    public void BuyMapHint(){
         MainMenuManager.hintData.hint.mapHint++;
         MainMenuManager.hintData.SaveData();
         MainMenuManager.uiMainMenuManager.mapHintCount.GetComponentInChildren<Text>().text = MainMenuManager.hintData.hint.mapHint.ToString();
    }
}
