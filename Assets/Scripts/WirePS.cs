using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePS : MonoBehaviour
{
    public GameObject PSCreate;
    bool exit = false;
    void Awake()
    {
        GameObject ps=Instantiate(PSCreate,transform.position,Quaternion.Euler(transform.eulerAngles));
    }

    void OnDestroy(){
        if (!exit){
        GameObject ps=Instantiate(PSCreate,transform.position,Quaternion.Euler(transform.eulerAngles));
        }
    }

    void OnApplicationQuit(){
        exit=true;
    }
}
