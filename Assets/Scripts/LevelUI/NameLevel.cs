using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("MainMenu"))
        gameObject.GetComponent<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("Level.Text")+" "+SceneManager.GetActiveScene().name.Split('_')[1];
    }
    public void NextLevel(){
        int level = int.Parse(SceneManager.GetActiveScene().name.Split('_')[1]);
        string levelName = Assets.SimpleLocalization.LocalizationManager.Localize("Level.Text")+" " + (level + 1);
        gameObject.GetComponent<Text>().text = levelName;
    }

    public void LoadLevel(int level){
        string levelName = Assets.SimpleLocalization.LocalizationManager.Localize("Level.Text")+" " + (level);
        gameObject.GetComponent<Text>().text = levelName;
    }
   public void LoadMainMenu(){
       gameObject.GetComponent<Text>().text = "Electro Dash";
   }
}
