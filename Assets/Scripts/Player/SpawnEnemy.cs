using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        Instantiate(enemy,transform.position,Quaternion.identity);
    }
}
