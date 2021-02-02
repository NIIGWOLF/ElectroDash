using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBarier : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Character>())
        {
            
            Character go = collider.gameObject.GetComponent<Character>();
            go.returnBack();
        }
    }
}
