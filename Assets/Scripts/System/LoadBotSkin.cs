using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBotSkin : MonoBehaviour
{
    void Awake()
    {
        EnemyActiv enemyActiv = gameObject.GetComponent<EnemyActiv>();

        var temp = Resources.Load("Shops/Bot/" + PlayerData.Instance.playerContent.Bots) as GameObject;
        gameObject.GetComponent<SpriteRenderer>().sprite = temp.GetComponent<SpriteRenderer>().sprite;
        foreach (Transform child in temp.transform)
        {
            var eye = Instantiate(child.gameObject, transform, false);
            if (child.name=="Eyes") enemyActiv.Eye=eye;
        }
    }
}
