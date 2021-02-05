using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPause : MonoBehaviour
{
    
    public void pause(){
        Invoke("method",0.5f);
    }
    public void method(){
        if (Time.timeScale != 0 ) {
            Time.timeScale = 0;
           }
        else {
            Time.timeScale = 1;
        }
    }
}
