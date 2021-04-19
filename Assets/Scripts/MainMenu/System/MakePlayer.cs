using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MakePlayer : MonoBehaviour
{
    void Start()
    {
        Player();
        Bot();
        Enemy();
       
    }
    public void Player()
    {
        /*MainMenuManager.uiMainMenuManager.Character.GetComponent<SpriteRenderer>().sprite = MainMenuManager.uiMainMenuManager.costumePrefabs[PlayerData.Instance.playerContent.Costume.ToString()].GetComponent<SpriteRenderer>().sprite;
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
                var a = Instantiate(MainMenuManager.uiMainMenuManager.psPrefabs[PlayerData.Instance.playerContent.Trails.ToString()], tr.transform);
                a.GetComponent<Transform>().localScale = new Vector3(2,2,2);
                var b = Instantiate(MainMenuManager.uiMainMenuManager.trailsPrefabs[PlayerData.Instance.playerContent.Trails.ToString()], tr.transform);
                b.GetComponent<Transform>().localScale = new Vector3(2,2,2);

            }
        }*/
        if (MainMenuManager.uiMainMenuManager.Character.transform.childCount!=0){
            for (int i=0; i<MainMenuManager.uiMainMenuManager.Character.transform.childCount; i++){
                Destroy(MainMenuManager.uiMainMenuManager.Character.transform.GetChild(i).gameObject);
            }
        }
        var a = Instantiate(MainMenuManager.uiMainMenuManager.costumePrefabs[PlayerData.Instance.playerContent.Costume.ToString()], MainMenuManager.uiMainMenuManager.Character.transform);
        var b = Instantiate(MainMenuManager.uiMainMenuManager.eyesPrefabs[PlayerData.Instance.playerContent.Costume.ToString()], MainMenuManager.uiMainMenuManager.Character.transform);
        var c = Instantiate(MainMenuManager.uiMainMenuManager.psPrefabs[PlayerData.Instance.playerContent.Trails.ToString()], MainMenuManager.uiMainMenuManager.Character.transform);
        c.GetComponent<Transform>().localScale = new Vector3(2,2,2);
        var d = Instantiate(MainMenuManager.uiMainMenuManager.trailsPrefabs[PlayerData.Instance.playerContent.Trails.ToString()], MainMenuManager.uiMainMenuManager.Character.transform);
        d.GetComponent<Transform>().localScale = new Vector3(2,2,2);

    }
    public void Enemy(){
        if (MainMenuManager.uiMainMenuManager.Enemy.transform.childCount!=0){
            Destroy(MainMenuManager.uiMainMenuManager.Enemy.transform.GetChild(0).gameObject);
        }
        var a = Instantiate(MainMenuManager.uiMainMenuManager.enemyPrefabs[PlayerData.Instance.playerContent.Enemyies.ToString()], MainMenuManager.uiMainMenuManager.Enemy.transform);
        foreach (Transform transform in a.GetComponentsInChildren<Transform>()){
            if (transform.gameObject.name.Contains("PS")){
                transform.GetComponent<Transform>().localScale = new Vector3(2,2,2);
            }
        }
    }
    public void Bot(){
        if (MainMenuManager.uiMainMenuManager.Bot.transform.childCount!=0){
            Destroy(MainMenuManager.uiMainMenuManager.Bot.transform.GetChild(0).gameObject);
        }
       var a = Instantiate(MainMenuManager.uiMainMenuManager.botPrefabs[PlayerData.Instance.playerContent.Bots.ToString()], MainMenuManager.uiMainMenuManager.Bot.transform);
       foreach (Transform transform in a.GetComponentsInChildren<Transform>()){
            if (transform.gameObject.name.Contains("PS")){
                transform.GetComponent<Transform>().localScale = new Vector3(1.5f,1.5f,1.5f);
            }
        }
    }
    public void Player(MenuData.ShopsData.COSTUME costume)
    {
        /*MainMenuManager.uiMainMenuManager.Character.GetComponent<SpriteRenderer>().sprite = MainMenuManager.uiMainMenuManager.costumePrefabs[costume.ToString()].GetComponent<SpriteRenderer>().sprite;
        foreach (Transform tr in MainMenuManager.uiMainMenuManager.Character.transform)
        {
            if (tr.gameObject.name.Equals("Eyes"))
            {
                tr.gameObject.GetComponent<SpriteRenderer>().sprite = MainMenuManager.uiMainMenuManager.eyesPrefabs[costume.ToString()].GetComponent<SpriteRenderer>().sprite;
            }
        }*/
        if (MainMenuManager.uiMainMenuManager.Character.transform.childCount!=0){
            for (int i=0; i<MainMenuManager.uiMainMenuManager.Character.transform.childCount; i++){
                if (MainMenuManager.uiMainMenuManager.Character.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>()==false)
                Destroy(MainMenuManager.uiMainMenuManager.Character.transform.GetChild(i).gameObject);
            }
        }
        var a = Instantiate( MainMenuManager.uiMainMenuManager.costumePrefabs[costume.ToString()], MainMenuManager.uiMainMenuManager.Character.transform);
        var b = Instantiate( MainMenuManager.uiMainMenuManager.eyesPrefabs[costume.ToString()], MainMenuManager.uiMainMenuManager.Character.transform);
        
    }

    public void Player(MenuData.ShopsData.TRAILS trail)
    {
        /*Transform tr = MainMenuManager.uiMainMenuManager.Character.transform.GetChild(1);

        if (tr.gameObject.name.Equals("ParticleSystem"))
        {
            if (tr.childCount != 0)
            {
                Destroy(tr.GetChild(0).gameObject);
                Destroy(tr.GetChild(1).gameObject);
            }
            var a = Instantiate(MainMenuManager.uiMainMenuManager.psPrefabs[trail.ToString()], tr.transform);
            var b = Instantiate(MainMenuManager.uiMainMenuManager.trailsPrefabs[trail.ToString()], tr.transform);
            a.GetComponent<Transform>().localScale = new Vector3(2,2,2);
            b.GetComponent<Transform>().localScale = new Vector3(2,2,2);

        }*/

         if (MainMenuManager.uiMainMenuManager.Character.transform.childCount!=0){
            for (int i=0; i<MainMenuManager.uiMainMenuManager.Character.transform.childCount; i++){
                if (MainMenuManager.uiMainMenuManager.Character.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>()==true)
                Destroy(MainMenuManager.uiMainMenuManager.Character.transform.GetChild(i).gameObject);
            }
        }
        var c = Instantiate(MainMenuManager.uiMainMenuManager.psPrefabs[trail.ToString()], MainMenuManager.uiMainMenuManager.Character.transform);
        c.GetComponent<Transform>().localScale = new Vector3(2.5f,2.5f,2.5f);
        var d = Instantiate(MainMenuManager.uiMainMenuManager.trailsPrefabs[trail.ToString()], MainMenuManager.uiMainMenuManager.Character.transform);
        d.GetComponent<Transform>().localScale = new Vector3(2.5f,2.5f,2.5f);

    }

    public void Player(MenuData.ShopsData.ENEMYIES enemy){
        if (MainMenuManager.uiMainMenuManager.Enemy.transform.childCount!=0){
            Destroy(MainMenuManager.uiMainMenuManager.Enemy.transform.GetChild(0).gameObject);
        }
        var a = Instantiate(MainMenuManager.uiMainMenuManager.enemyPrefabs[enemy.ToString()], MainMenuManager.uiMainMenuManager.Enemy.transform);
        foreach (Transform transform in a.GetComponentsInChildren<Transform>()){
            if (transform.gameObject.name.Contains("PS")){
                transform.GetComponent<Transform>().localScale = new Vector3(2,2,2);
            }
        }
    }
    public void Player(MenuData.ShopsData.BOTS bots){
        if (MainMenuManager.uiMainMenuManager.Bot.transform.childCount!=0){
            Destroy(MainMenuManager.uiMainMenuManager.Bot.transform.GetChild(0).gameObject);
        }
       var a = Instantiate(MainMenuManager.uiMainMenuManager.botPrefabs[bots.ToString()], MainMenuManager.uiMainMenuManager.Bot.transform);
       foreach (Transform transform in a.GetComponentsInChildren<Transform>()){
            if (transform.gameObject.name.Contains("PS")){
                transform.GetComponent<Transform>().localScale = new Vector3(1.5f,1.5f,1.5f);
            }
        }
    }

}
