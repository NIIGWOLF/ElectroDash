using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertBarier : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>()){
            collider.GetComponent<Player>().invert=true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>()){
            collider.GetComponent<Player>().invert=false;
        }
    }
}
