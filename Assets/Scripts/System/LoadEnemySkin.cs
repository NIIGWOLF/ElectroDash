using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemySkin : MonoBehaviour
{
    void Awake()
    {
        Enemy enemy = gameObject.GetComponent<Enemy>();

        var temp = Resources.Load("Shops/Enemy/" + PlayerData.Instance.playerContent.Enemyies) as GameObject;
        gameObject.GetComponent<SpriteRenderer>().sprite = temp.GetComponent<SpriteRenderer>().sprite;
        foreach (Transform child in temp.transform)
        {
            var eye = Instantiate(child.gameObject, transform, false);
            if (child.name=="Eyes") enemy.Eye=eye;
        }
    }
}
