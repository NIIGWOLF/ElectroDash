using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNextLevel : MonoBehaviour
{
   public void LoadLevel()
    {
        int level = int.Parse(SceneManager.GetActiveScene().name.Split('_')[1]);
        string levelName = "level_" + (level + 1);
        print(levelName);
        if (Application.CanStreamedLevelBeLoaded(levelName)) {
            StaticManager.nameLevel.NextLevel();
            StaticManager.loadScene.BeforeNewScene();
            Invoke("LoadLevelScene",0.61f);
        }
        else
        {
            Debug.Log("no Scene");
        }
    }
    void LoadLevelScene(){
        int level = int.Parse(SceneManager.GetActiveScene().name.Split('_')[1]);
        string levelName = "level_" + (level + 1);
        SceneManager.LoadScene(levelName);
    }
}
