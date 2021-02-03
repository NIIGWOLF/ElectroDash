using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MainMenu()
    {
        if (Application.CanStreamedLevelBeLoaded("MainMenu")) {
            StaticManager.loadScene.BeforeNewScene();
            Invoke("LoadNewScene",0.59f);
        }
        else
        {
            Debug.Log("no Scene");
        }
    }
    void LoadNewScene(){
        SceneManager.LoadScene("MainMenu");
    }
}
