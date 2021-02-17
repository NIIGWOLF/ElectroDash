using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHint : MonoBehaviour
{
    public void BuySimpleHint(){
         HintData.Instance.hint.simpleHint++;
         HintData.Instance.SaveData();
         MainMenuManager.uiMainMenuManager.simpleHintCount.GetComponentInChildren<Text>().text = HintData.Instance.hint.simpleHint.ToString();
        
    }
    public void BuyMapHint(){
         HintData.Instance.hint.mapHint++;
         HintData.Instance.SaveData();
         MainMenuManager.uiMainMenuManager.mapHintCount.GetComponentInChildren<Text>().text = HintData.Instance.hint.mapHint.ToString();
    }
}
