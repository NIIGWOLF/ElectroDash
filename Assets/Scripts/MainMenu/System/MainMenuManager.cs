using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static UIMainMenuManager uiMainMenuManager; //загрузка класса 
    public static MakePlayer makePlayer;
    public static LoadScene loadScene;
    public static NameLevel nameLevel; 
    public static int levelCount = 100;

   public static int stateMenu = 0;
    void Awake()
    {
        uiMainMenuManager = Object.FindObjectsOfType<UIMainMenuManager>()[0];
        makePlayer = Object.FindObjectOfType<MakePlayer>();
        loadScene = Object.FindObjectOfType<LoadScene>();
        nameLevel = Object.FindObjectOfType<NameLevel>();
    }

    

}
