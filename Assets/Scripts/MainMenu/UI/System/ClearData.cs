using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ClearData : MonoBehaviour
{
     public void Clear(){
        Directory.Delete(Application.persistentDataPath+"/Data/MainMenuData",true);
        File.Delete(Application.persistentDataPath + "/Data/Player.json");
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name, LoadSceneMode.Single);
    }
}
