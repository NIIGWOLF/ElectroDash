using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : Character
{

    public override void Die()
    {
        //Instantiate(deathPS,transform.position,Quaternion.identity);
        gameObject.GetComponent<Collider2D>().enabled=false;
        foreach(ParticleSystem ps in gameObject.GetComponentsInChildren<ParticleSystem>()){
            ps.Stop();
        }
        ScriptManager.objectManager.AllCharacter.Remove(gameObject);
        Sequence sequence= DOTween.Sequence();
        sequence.Append(gameObject.transform.DOShakePosition(1f, new Vector3(0.05f,0.05f,0),100,90,false,true));
        foreach(SpriteRenderer spr in gameObject.GetComponentsInChildren<SpriteRenderer>()){
            sequence.Join(spr.DOFade(0,1));
        }
        sequence.OnComplete(OnDie);
    }
    public void OnDie(){
        Destroy(gameObject);
    }
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            if (transform.position.Equals(nextPos))
            {
                currentPos = nextPos;
                nextPos = tileMap.GetInstantiatedObject(nextPos).GetComponent<BasePoint>().InComming(backPos,false, gameObject);
                if (nextPos.z == 0)
                {
                    backPos = currentPos;
                    tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(false);
                    AnimatedEye();
                }
                else
                {
                    isMove = false;
                    enterBarier = false;
                    AnimatedStopMove();
                }
            }
        }
        else
        {
            if (isTransportation) return;
            timeleft -= Time.deltaTime;
            if (timeleft < 0)
            {
                timeleft = time + Random.Range(-0.1f, 0.1f);
                
                for(int i=0; i<3;i++){
                    nextPos = NextPos();
                    if (nextPos!=backPos) break;
                }

                if (nextPos==new Vector3Int(0, 0, 1)) return;
                backPos = currentPos;
                tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(false);
                AnimatedEye();
                isMove = true;
            }
        }
    }

    Vector3Int NextPos()
    {
        GameObject goTemp;
        List<Vector3Int> tempList = new List<Vector3Int>();
        for (int i = -1; i <= 1; i += 2)
        {
            goTemp = tileMap.GetInstantiatedObject(currentPos + new Vector3Int(i, 0, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                        tempList.Add(currentPos + new Vector3Int(i, 0, 0));
                }
            }

            goTemp = tileMap.GetInstantiatedObject(currentPos + new Vector3Int(0, i, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                        tempList.Add(currentPos + new Vector3Int(0, i, 0));
                }
            }
        }
        if (tempList.Count == 0) {
            return new Vector3Int(0, 0, 1);
        }
        else {
            AnimatedStartMove();
            return tempList[Random.Range(0, tempList.Count)];
        }
    }

    public override void Transportation(bool transportation){
        isTransportation=transportation;
        timeleft=0.01f;
    }

    protected  void  OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.GetComponent<Player>()){
            collider.gameObject.GetComponent<Player>().Die();
            return;
        }
        /*
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
            timeleft+=0.2f;
        }*/
    }
}
