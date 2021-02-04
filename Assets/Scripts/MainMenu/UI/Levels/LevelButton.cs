using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    private int levelOpenCoins;
    private int levelNumber;
    public GameObject leftCoin;
    public GameObject centreCoin;
    public GameObject rightCoin;
    public Color noCoin;
    void Start()
    {
        levelNumber = int.Parse(gameObject.GetComponentInChildren<Text>().text.Split(' ')[1]);
        levelOpenCoins = MainMenuManager.levelData.levelInfo.levelStars[levelNumber];
         switch(levelOpenCoins){
             case 0:
                leftCoin.gameObject.GetComponent<Image>().color = noCoin;
                centreCoin.gameObject.GetComponent<Image>().color = noCoin;
                rightCoin.gameObject.GetComponent<Image>().color = noCoin;
                break;
            case 1:
                leftCoin.gameObject.GetComponent<Image>().color = Color.white;
                centreCoin.gameObject.GetComponent<Image>().color = noCoin;
                rightCoin.gameObject.GetComponent<Image>().color = noCoin;
                break;
            case 2:
                leftCoin.gameObject.GetComponent<Image>().color = Color.white;
                centreCoin.gameObject.GetComponent<Image>().color = Color.white;
                rightCoin.gameObject.GetComponent<Image>().color = noCoin;
                break;
            case 3:
                leftCoin.gameObject.GetComponent<Image>().color = Color.white;
                centreCoin.gameObject.GetComponent<Image>().color = Color.white;
                rightCoin.gameObject.GetComponent<Image>().color = Color.white;
                break;
         }
    }
    public void LoadLevel()
    {
        int level = int.Parse(gameObject.GetComponentInChildren<Text>().text.Split(' ')[1]);
        string levelName = "level_" + level;
        if (Application.CanStreamedLevelBeLoaded(levelName)) {
            MainMenuManager.nameLevel.LoadLevel(level);
            MainMenuManager.loadScene.BeforeNewScene();
            Invoke("LoadLevelScene",0.61f);
        }
        else
        {
            Debug.Log("no Scene");
        }
    }
    void LoadLevelScene(){
        int level = int.Parse(gameObject.GetComponentInChildren<Text>().text.Split(' ')[1]);
        string levelName = "level_" + level;
        SceneManager.LoadScene(levelName);
    }

}
