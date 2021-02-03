using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBarier : MonoBehaviour
{
    void Awake()
    {
        gameObject.transform.localScale = new Vector3(Screen.width+5,Screen.height+5,1)*0.2f;
    }
}
