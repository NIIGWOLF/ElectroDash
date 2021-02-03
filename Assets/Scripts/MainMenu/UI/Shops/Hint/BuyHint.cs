using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHint : MonoBehaviour
{
    public void BuySimpleHint(){
         MainMenuManager.hintData.hint.simpleHint++;
         MainMenuManager.hintData.SaveData();
         print("simple + 1");
         print(MainMenuManager.hintData.hint.simpleHint);
    }
    public void BuyMapHint(){
         MainMenuManager.hintData.hint.mapHint++;
         MainMenuManager.hintData.SaveData();
         print("map + 1");
    }
}
