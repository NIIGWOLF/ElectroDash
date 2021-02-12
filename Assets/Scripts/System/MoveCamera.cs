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
        transform.position=new Vector3(target.transform.position.x,target.transform.position.y,addPos.z);
    }

    void Update()
    {
        if (target)
        {
            if (Vector2.Distance(target.transform.position, transform.position) > 0.1f)
            {
                transform.position = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime*4);
                transform.position += addPos;
            }
        }
    }

}
