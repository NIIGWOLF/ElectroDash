using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MakePlayer : MonoBehaviour
{
    void Start(){
        Player();
    }
    public void Player(){
        MainMenuManager.uiMainMenuManager.Character.GetComponent<SpriteRenderer>().sprite =MainMenuManager.uiMainMenuManager.costumePrefabs[MainMenuManager.playerData.playerContent.costume.ToString()].GetComponent<SpriteRenderer>().sprite;
    }
    public void Player(MenuData.ShopsData.COSTUME costume){
        MainMenuManager.uiMainMenuManager.Character.GetComponent<SpriteRenderer>().sprite =MainMenuManager.uiMainMenuManager.costumePrefabs[costume.ToString()].GetComponent<SpriteRenderer>().sprite;
    }
    
}
