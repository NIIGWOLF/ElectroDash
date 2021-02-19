using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public static LoadScene loadScene;
    public static NameLevel nameLevel;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        loadScene = Object.FindObjectOfType<LoadScene>();
        nameLevel =  Object.FindObjectOfType<NameLevel>();
    }

    
}
