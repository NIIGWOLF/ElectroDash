using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    private float timeleft = 1;

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
                }
                else
                {
                    isMove = false;
                }
            }
        }
        else
        {
            timeleft -= Time.deltaTime;
            if (timeleft < 0)
            {
                timeleft = 1;
                nextPos = NextPos();
                backPos = currentPos;
                Debug.Log(currentPos);
                tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(false);
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
        if (tempList.Count == 0) return new Vector3Int(0, 0, 1);
        else return tempList[Random.Range(0, tempList.Count)];
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.GetComponent<Player>()){
            collider.gameObject.GetComponent<Player>().Die();
            return;
        }
        if (collider.gameObject.GetComponent<Character>()){
            returnBack();
        }
    }
}
