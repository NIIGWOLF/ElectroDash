﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        var go = Instantiate(player,transform.position,Quaternion.identity);
        ScriptManager.objectManager.AllCharacter.Add(go);
    }
}
