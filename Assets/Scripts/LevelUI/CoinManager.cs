using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject uiCoin1;
    public GameObject uiCoin2;
    public GameObject uiCoin3;

    public int countCoin = 0;
    public int oldCountCoin = 0;
    private int nLevel;
    void Awake()
    {

        int.TryParse(SceneManager.GetActiveScene().name.Split('_')[1], out nLevel);
        
        if (LevelData.Instance.levelInfo.levelActivStars.Count > nLevel)
        {
            var strCoin = LevelData.Instance.levelInfo.levelActivStars[nLevel];
            if (strCoin[0] == '1')
            {
                countCoin++;
                oldCountCoin++;
                coin1.SetActive(false);
            }
            if (strCoin[1] == '1')
            {
                countCoin++;
                oldCountCoin++;
                coin2.SetActive(false);
            }
            if (strCoin[2] == '1')
            {
                countCoin++;
                oldCountCoin++;
                coin3.SetActive(false);
            }

        }
        else
        {
            LevelData.Instance.levelInfo.levelActivStars.Add("000");
            LevelData.Instance.levelInfo.levelStars.Add(0);
            LevelData.Instance.SaveData();
        }
    }

    public void ActivUI()
    {
        switch (countCoin)
        {
            case 0:
                uiCoin1.SetActive(false);
                uiCoin2.SetActive(false);
                uiCoin3.SetActive(false);
                break;
            case 1:
                uiCoin1.SetActive(true);
                uiCoin2.SetActive(false);
                uiCoin3.SetActive(false);
                break;
            case 2:
                uiCoin1.SetActive(true);
                uiCoin2.SetActive(true);
                uiCoin3.SetActive(false);
                break;
            case 3:
                uiCoin1.SetActive(true);
                uiCoin2.SetActive(true);
                uiCoin3.SetActive(true);
                break;
        }
    }

    public void SaveActivStars()
    {
        string str = "";

        if (coin1.activeSelf) str += "0";
        else str += "1";
        if (coin2.activeSelf) str += "0";
        else str += "1";
        if (coin3.activeSelf) str += "0";
        else str += "1";

        LevelData.Instance.levelInfo.levelActivStars[nLevel] = str;
        LevelData.Instance.levelInfo.levelStars[nLevel]=countCoin;
        if (LevelData.Instance.levelInfo.lastOpenLevel<=nLevel){
            LevelData.Instance.levelInfo.lastOpenLevel=nLevel+1;
            HintData.Instance.hint.simpleHint++;
            HintData.Instance.hint.mapHint++;
            HintData.Instance.SaveData();
         
        }
        LevelData.Instance.SaveData();
        CountData.Instance.amountData.coins +=countCoin-oldCountCoin;
        CountData.Instance.SaveData();
    }
}
