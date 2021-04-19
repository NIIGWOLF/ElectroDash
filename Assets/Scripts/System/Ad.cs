using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Advertisement.isSupported){
            Advertisement.Initialize("4092201",true);
        }
        Invoke("pokaz",2);
    }

    void pokaz(){
        print("pokaz");
        if (Advertisement.IsReady()){
            print("Show");
            Advertisement.Show();
        }
        else
        print("Don't show");
        
    }
}
