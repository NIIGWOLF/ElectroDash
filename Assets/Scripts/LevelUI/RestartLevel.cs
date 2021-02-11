using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevel : MonoBehaviour
{
    
    private Scene activeScene;
    public void Restart()
    {
        ScriptManager.objectManager.activStartDaethPS=false;
        activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name, LoadSceneMode.Single);
        if (Time.timeScale == 0 ) Time.timeScale = 1;
       
    }
}
