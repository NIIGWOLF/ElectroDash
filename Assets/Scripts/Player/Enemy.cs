using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    private float timeleft = 1;
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            if (transform.position.Equals(nextPos))
            {
                currentPos = nextPos;
                nextPos = NextPosBack(backPos);
                if (nextPos.z == 0)
                {
                    backPos = currentPos;
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

    protected virtual Vector3Int NextPosBack(Vector3Int backPos)
    {
        Vector3Int temp = new Vector3Int(0, 0, 1);
        var tileMap = ScriptManager.objectManager.tilemap;

        GameObject goTemp;
        int countCell = 0;
        for (int i = -1; i <= 1; i += 2)
        {

            goTemp = tileMap.GetInstantiatedObject(currentPos + new Vector3Int(i, 0, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    countCell++;
                    if (!backPos.Equals(currentPos + new Vector3Int(i, 0, 0)))
                    {
                        temp = currentPos + new Vector3Int(i, 0, 0);
                    }
                }
            }

            goTemp = tileMap.GetInstantiatedObject(currentPos + new Vector3Int(0, i, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    countCell++;
                    if (!backPos.Equals(currentPos + new Vector3Int(0, i, 0)))
                    {
                        temp = currentPos + new Vector3Int(0, i, 0);
                    }
                }
            }

        }

        if (countCell == 2)
        {
            return temp;
        }
        else return new Vector3Int(0, 0, 1);
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
