using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static UIMainMenuManager uiMainMenuManager; //загрузка класса 
    public static PlayerData playerData; 
    public static MenuData menuData;
    public static CountData countData;
    public static MakePlayer makePlayer;
    public static LevelData levelData;
    public static LoadScene loadScene;
    public static HintData hintData;
    public static NameLevel nameLevel; 
   
    void Awake()
    {
        uiMainMenuManager = Object.FindObjectsOfType<UIMainMenuManager>()[0];
        menuData = Object.FindObjectOfType<MenuData>();
        playerData = Object.FindObjectOfType<PlayerData>();
        countData = Object.FindObjectOfType<CountData>();
        makePlayer = Object.FindObjectOfType<MakePlayer>();
        levelData = Object.FindObjectOfType<LevelData>();
        loadScene = Object.FindObjectOfType<LoadScene>();
        hintData = Object.FindObjectOfType<HintData>();
        nameLevel = Object.FindObjectOfType<NameLevel>();
      

    }

}
