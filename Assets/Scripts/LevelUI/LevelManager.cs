﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public  GameObject countSimpleHint;
    public  GameObject countMapHint;
    public GameObject levelCompleteCanvas;
    public CoinManager coinManager;
    
   
    // Start is called before the first frame update
    void Start()
    {
        countSimpleHint.GetComponent<Text>().text = StaticManager.hintData.hint.simpleHint.ToString();
        countMapHint.GetComponent<Text>().text = StaticManager.hintData.hint.mapHint.ToString();

    }

}