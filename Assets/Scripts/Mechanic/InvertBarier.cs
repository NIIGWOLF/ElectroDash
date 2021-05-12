using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertBarier : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>()){
            if (!collider.GetComponent<Player>().invert.Contains(gameObject))
            collider.GetComponent<Player>().invert.Add(gameObject);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>()){
           if (collider.GetComponent<Player>().invert.Contains(gameObject))
            collider.GetComponent<Player>().invert.Remove(gameObject);
        }
    }
}
