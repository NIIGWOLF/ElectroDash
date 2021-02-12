using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPause : MonoBehaviour
{
    [Range(0,1f)] public float timeScale=0;  
    public void pause(){
        Time.timeScale = timeScale;
    }
}
