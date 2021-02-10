using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyActiv : MonoBehaviour
{
    public GameObject enemyActiv;
    void Start()
    {
        var go = Instantiate(enemyActiv,transform.position,Quaternion.identity);
        ScriptManager.objectManager.AllCharacter.Add(go);
    }
}
