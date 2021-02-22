using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayGame : MonoBehaviour
{
     int lastOpenLevel;
    // Start is called before the first frame update
    void Start()
    {
        lastOpenLevel = LevelData.Instance.levelInfo.lastOpenLevel;
    }
    public void LoadLastOpenLevel(){
        string levelName = "level_" + lastOpenLevel;
        if (Application.CanStreamedLevelBeLoaded(levelName)) {
            MainMenuManager.nameLevel.LoadLevel(lastOpenLevel);
            MainMenuManager.loadScene.BeforeNewScene();
            Invoke("LoadLevelScene",0.61f);
        }
        else
        {
            Debug.Log("no Scene");
        }
    }
    void LoadLevelScene(){
        string levelName = "level_" + lastOpenLevel;
        SceneManager.LoadScene(levelName);
    }
}
