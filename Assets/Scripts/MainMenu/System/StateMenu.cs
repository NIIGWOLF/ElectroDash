using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateMenu : MonoBehaviour
{

    public Button backLevels;
    public Button backShop;
    public Button backSetting;
    public Button backInfo;
    public Button backCostume;
    public Button backHint;
    public Button backTrails;
    public Button backEnemy;
    public Button backBot;



    void Update()
    {

        // if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (MainMenuManager.stateMenu == 0)
                    Application.Quit();
                else
                {
                   // print("State!!! " + MainMenuManager.stateMenu);
                    //if (MainMenuManager.stateMenu == state)
                    {
                        switch (MainMenuManager.stateMenu)
                        {
                            case 1:
                                backLevels.onClick.Invoke();
                                MainMenuManager.stateMenu = 0;
                                break;
                            case 2:
                                backShop.onClick.Invoke();
                                MainMenuManager.stateMenu = 0;
                                break;
                            case 3:
                                backCostume.onClick.Invoke();
                                MainMenuManager.stateMenu = 2;
                                break;
                            case 4:
                                backHint.onClick.Invoke();
                                MainMenuManager.stateMenu = 2;
                                break;
                            case 5:
                                backTrails.onClick.Invoke();
                                MainMenuManager.stateMenu = 2;
                                break;
                            case 6:
                                backEnemy.onClick.Invoke();
                                MainMenuManager.stateMenu = 2;
                                break;
                            case 7:
                                backBot.onClick.Invoke();
                                MainMenuManager.stateMenu = 2;
                                break;
                            case 8:
                                backSetting.onClick.Invoke();
                                MainMenuManager.stateMenu = 0;
                                break;
                            case 9:
                                backInfo.onClick.Invoke();
                                MainMenuManager.stateMenu = 0;
                                break;


                        }

                    }
                }
            }
        }
    }
}
