using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class Character : MonoBehaviour
{
    protected bool isMove = false;
    protected Vector3Int backPos;
    protected Vector3Int nextPos = new Vector3Int(0, 0, 1);
    protected Vector3Int currentPos;
    protected float speed = 5f;
    protected Tilemap tileMap;
    protected float timeleft = 1;
    public float time = 1;

    private Vector3 scale;

    public GameObject Eye;

    protected virtual void Start()
    {
        scale = gameObject.transform.localScale;
        backPos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        currentPos = Vector3Int.CeilToInt(transform.position);
    }

    public virtual void returnBack()
    {
        if (isMove)
        {
            Vector3Int temp = backPos;
            backPos = nextPos;
            nextPos = temp;
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void AnimatedStartMove(){
        gameObject.transform.localScale = scale;
        gameObject.transform.DOShakeScale(0.2f,0.2f,15,90,true);
    }

    public virtual void AnimatedStopMove(){
        gameObject.transform.localScale = scale;
        Eye.transform.DOLocalMove(Vector3.zero,0.1f);
    }

    public virtual void AnimatedEye(){
        var pos = (Vector3)(nextPos-currentPos)*0.03f;
        if (Eye.transform.localPosition!=pos)
            Eye.transform.DOLocalMove(pos,0.2f);
    }


    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (isMove)
        {
            if (collider.gameObject.GetComponent<Character>())
            {
                Vector3 vecChar = (transform.position - collider.transform.position);

                if (Mathf.Abs(vecChar.x) < Mathf.Abs(vecChar.y))
                {
                    if ((currentPos - nextPos).y != 0)
                    {
                        returnBack();
                    }
                }
                else
                {
                    if ((currentPos - nextPos).x != 0)
                    {
                        returnBack();
                    }
                }
            }
        }
        else
        {
            timeleft += 0.1f;
        }
    }
}

