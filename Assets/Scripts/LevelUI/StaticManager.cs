using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    
    public static HintData hintData;
    public static LevelManager levelManager;
    public static LoadScene loadScene;
    // Start is called before the first frame update
    void Start()
    {
        hintData = Object.FindObjectOfType<HintData>();
        levelManager = Object.FindObjectOfType<LevelManager>();
        loadScene = Object.FindObjectOfType<LoadScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
