using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        print(MainMenuManager.levelData.levelInfo.levelStars.Count);
        print("Begin");
        for (int i=0; i<MainMenuManager.levelData.levelInfo.levelStars.Count; i++){
            print(MainMenuManager.levelData.levelInfo.levelStars[i]);
        }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
