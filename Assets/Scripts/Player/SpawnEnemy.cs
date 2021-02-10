using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        var go = Instantiate(enemy,transform.position,Quaternion.identity);
        ScriptManager.objectManager.AllCharacter.Add(go);
    }
}
