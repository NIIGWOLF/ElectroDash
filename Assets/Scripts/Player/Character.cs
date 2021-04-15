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
    public GameObject deathPS;
    protected bool isTransportation = false;

    protected Vector3Int diePos;

    private Vector3 scale;

    public GameObject Eye;
    [Range(0.01f,0.5f)]public float eyeOffset=0.03f;

    public bool enterBarier;



    public Vector3Int NextPos { get => nextPos; set => nextPos = value; }
    public Vector3Int CurrentPos { get => currentPos; set => currentPos = value; }
    public bool IsMove { get => isMove; set => isMove = value; }
    public bool IsTransportation { get => isTransportation; }

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
        ScriptManager.objectManager.AllCharacter.Remove(gameObject);
        Destroy(gameObject);
    }

    public virtual void Die(Vector3Int pos){
        diePos=pos;
        Invoke("isDie",0.02f);
    }

    public virtual void isDie(){
        if (currentPos==diePos || nextPos==diePos) {
            var go = tileMap.GetInstantiatedObject(diePos);
            BasePoint bp = null;
            if (go!=null)
                bp = go.GetComponent<BasePoint>();
            if (bp==null)
                Die();
            
        }
    }

    public virtual void Transportation(bool transportation){

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
        var pos = (Vector3)(nextPos-currentPos)*eyeOffset;
        if (Eye.transform.localPosition!=pos)
            Eye.transform.DOLocalMove(pos,0.2f);
    }

    protected virtual void OnTriggerStay2D(Collider2D collider){
        if (isMove)
        {
            if (collider.gameObject.GetComponent<Character>())
            {
                if(Vector3.Distance(transform.position,nextPos)>Vector3.Distance(collider.transform.position,nextPos)){
                    returnBack();
                }
            }
            if (enterBarier){
                if (collider.GetComponent<PowerBarier>()){
                    if (collider.bounds.Contains(nextPos)) returnBack();
                }
            }
        }
    }




    /*protected virtual void OnTriggerEnter2D(Collider2D collider)
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
    }*/
}

