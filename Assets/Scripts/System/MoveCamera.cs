using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoBehaviour
{
    Sequence sequence;
    GameObject target;
    public Vector3 addPos = new Vector3(0, 0, -10);

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target)
        {
            Debug.Log(Vector2.Distance(target.transform.position, transform.position));
            if (Vector2.Distance(target.transform.position, transform.position) > 0.1f)
            {
                transform.position = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime*4);
                transform.position += addPos;
            }
        }
    }

}
