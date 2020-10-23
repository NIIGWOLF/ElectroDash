using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyActiv : MonoBehaviour
{
    public GameObject enemyActiv;
    void Start()
    {
        Instantiate(enemyActiv,transform.position,Quaternion.identity);
    }
}
