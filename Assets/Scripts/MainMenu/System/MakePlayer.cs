using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MakePlayer : MonoBehaviour
{
    void Start()
    {
        Player();
        Enemy();
        Bot();
    }
    public void Player()
    {
        MainMenuManager.uiMainMenuManager.Character.GetComponent<SpriteRenderer>().sprite = MainMenuManager.uiMainMenuManager.costumePrefabs[PlayerData.Instance.playerContent.Costume.ToString()].GetComponent<SpriteRenderer>().sprite;
        foreach (Transform tr in MainMenuManager.uiMainMenuManager.Character.transform)
        {
            if (tr.gameObject.name.Equals("Eyes"))
            {
                tr.gameObject.GetComponent<SpriteRenderer>().sprite = MainMenuManager.uiMainMenuManager.eyesPrefabs[PlayerData.Instance.playerContent.Costume.ToString()].GetComponent<SpriteRenderer>().sprite;
            }
            if (tr.gameObject.name.Equals("ParticleSystem"))
            {
                if (tr.childCount != 0)
                {
                    Destroy(tr.GetChild(0).gameObject);
                    Destroy(tr.GetChild(1).gameObject);
                }
                Instantiate(MainMenuManager.uiMainMenuManager.psPrefabs[PlayerData.Instance.playerContent.Trails.ToString()], tr.transform);
                Instantiate(MainMenuManager.uiMainMenuManager.trailsPrefabs[PlayerData.Instance.playerContent.Trails.ToString()], tr.transform);


            }
        }
    }
    public void Enemy(){
        if (MainMenuManager.uiMainMenuManager.Enemy.transform.childCount!=0){
            Destroy(MainMenuManager.uiMainMenuManager.Enemy.transform.GetChild(0).gameObject);
        }
        Instantiate(MainMenuManager.uiMainMenuManager.enemyPrefabs[PlayerData.Instance.playerContent.Enemyies.ToString()], MainMenuManager.uiMainMenuManager.Enemy.transform);
    }
    public void Bot(){
        if (MainMenuManager.uiMainMenuManager.Bot.transform.childCount!=0){
            Destroy(MainMenuManager.uiMainMenuManager.Bot.transform.GetChild(0).gameObject);
        }
        Instantiate(MainMenuManager.uiMainMenuManager.botPrefabs[PlayerData.Instance.playerContent.Bots.ToString()], MainMenuManager.uiMainMenuManager.Bot.transform);
    }
    public void Player(MenuData.ShopsData.COSTUME costume)
    {
        MainMenuManager.uiMainMenuManager.Character.GetComponent<SpriteRenderer>().sprite = MainMenuManager.uiMainMenuManager.costumePrefabs[costume.ToString()].GetComponent<SpriteRenderer>().sprite;
        foreach (Transform tr in MainMenuManager.uiMainMenuManager.Character.transform)
        {
            if (tr.gameObject.name.Equals("Eyes"))
            {
                tr.gameObject.GetComponent<SpriteRenderer>().sprite = MainMenuManager.uiMainMenuManager.eyesPrefabs[costume.ToString()].GetComponent<SpriteRenderer>().sprite;
            }

        }
    }

    public void Player(MenuData.ShopsData.TRAILS trail)
    {
        Transform tr = MainMenuManager.uiMainMenuManager.Character.transform.GetChild(1);

        if (tr.gameObject.name.Equals("ParticleSystem"))
        {
            if (tr.childCount != 0)
            {
                Destroy(tr.GetChild(0).gameObject);
                Destroy(tr.GetChild(1).gameObject);
            }
            Instantiate(MainMenuManager.uiMainMenuManager.psPrefabs[trail.ToString()], tr.transform);
            Instantiate(MainMenuManager.uiMainMenuManager.trailsPrefabs[trail.ToString()], tr.transform);


        }

    }

    public void Player(MenuData.ShopsData.ENEMYIES enemy){
        if (MainMenuManager.uiMainMenuManager.Enemy.transform.childCount!=0){
            Destroy(MainMenuManager.uiMainMenuManager.Enemy.transform.GetChild(0).gameObject);
        }
        Instantiate(MainMenuManager.uiMainMenuManager.enemyPrefabs[enemy.ToString()], MainMenuManager.uiMainMenuManager.Enemy.transform);
    }
    public void Player(MenuData.ShopsData.BOTS bots){
        if (MainMenuManager.uiMainMenuManager.Bot.transform.childCount!=0){
            Destroy(MainMenuManager.uiMainMenuManager.Bot.transform.GetChild(0).gameObject);
        }
        Instantiate(MainMenuManager.uiMainMenuManager.botPrefabs[bots.ToString()], MainMenuManager.uiMainMenuManager.Bot.transform);
    }

}
