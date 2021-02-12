using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartAfterDeath : MonoBehaviour
{
    void Start()
    {
        Invoke("Restart",1.75f);
        
    }
    
    void Restart(){
        ScriptManager.objectManager.activStartDaethPS=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }


}

