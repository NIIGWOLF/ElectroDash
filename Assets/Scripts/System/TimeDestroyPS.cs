using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyPS : MonoBehaviour
{
    [Range(0f,10f)] public float time = 1;
    void Start()
    {
        Invoke("DestroyPS",time);
    }

    void DestroyPS(){
        Destroy(gameObject);
    }

}
