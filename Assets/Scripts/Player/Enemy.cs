using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            if (transform.position.Equals(nextPos))
            {
                currentPos = nextPos;
                nextPos = tileMap.GetInstantiatedObject(nextPos).GetComponent<BasePoint>().InComming(backPos,false);
                if (nextPos.z == 0)
                {
                    backPos = currentPos;
                    tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(false);
                    AnimatedEye();
                }
                else
                {
                    isMove = false;
                    AnimatedStopMove();
                }
            }
        }
        else
        {
            timeleft -= Time.deltaTime;
            if (timeleft < 0)
            {
                timeleft = time;
                nextPos = NextPos();
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
            AnimatedStartMove();
            return new Vector3Int(0, 0, 1);
        }
        else return tempList[Random.Range(0, tempList.Count)];
    }

    protected override void  OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.GetComponent<Player>()){
            collider.gameObject.GetComponent<Player>().Die();
            return;
        }
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
        }
    }
}
