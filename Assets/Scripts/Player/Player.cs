using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private bool isMove = false;
    private Vector3Int backPos;
    private Vector3Int nextPos = new Vector3Int(0, 0, 1);
    private Vector3Int currentPos;
    private Sequence seq;
    private float speed = 5f;
    private Ease ease = Ease.Linear;
    private Tilemap tileMap;
    // Start is called before the first frame update
    void Start()
    {
        backPos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        currentPos = Vector3Int.CeilToInt(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
            if (transform.position.Equals(nextPos))
            {
                currentPos = nextPos;
                nextPos = tileMap.GetInstantiatedObject(nextPos).GetComponent<BasePoint>().InComming(backPos);
                if (nextPos.z == 0)
                {
                    backPos = currentPos;
                    tileMap.GetInstantiatedObject(nextPos).GetComponent<BasePoint>().OutComming();
                }
                else
                {
                    isMove = false;
                }
            }
        }
    }

    public void Swipe(int rot)
    {
        seq = DOTween.Sequence();
        GameObject goTemp;
        Debug.Log("swipe");
        switch (rot)
        {
            case 0: //up
                goTemp = tileMap.GetInstantiatedObject(currentPos + new Vector3Int(0, 1, 0));
                if (goTemp != null)
                {
                    if (goTemp.GetComponent<BasePoint>())
                    {
                        backPos = currentPos;
                        nextPos = currentPos + new Vector3Int(0, 1, 0);
                        goTemp.GetComponent<BasePoint>().OutComming();
                        isMove = true;
                    }
                }
                break;
            case 1: //right
                goTemp = tileMap.GetInstantiatedObject(currentPos + new Vector3Int(1, 0, 0));
                if (goTemp != null)
                {
                    if (goTemp.GetComponent<BasePoint>())
                    {
                        backPos = currentPos;
                        nextPos = currentPos + new Vector3Int(1, 0, 0);
                        goTemp.GetComponent<BasePoint>().OutComming();
                        isMove = true;
                    }
                }
                break;
            case 2: //down
                goTemp = tileMap.GetInstantiatedObject(currentPos + new Vector3Int(0, -1, 0));
                if (goTemp != null)
                {
                    if (goTemp.GetComponent<BasePoint>())
                    {
                        backPos = currentPos;
                        nextPos = currentPos + new Vector3Int(0, -1, 0);
                        goTemp.GetComponent<BasePoint>().OutComming();
                        isMove = true;
                    }
                }
                break;
            case 3: //left
                goTemp = tileMap.GetInstantiatedObject(currentPos + new Vector3Int(-1, 0, 0));
                if (goTemp != null)
                {
                    if (goTemp.GetComponent<BasePoint>())
                    {
                        backPos = currentPos;
                        nextPos = currentPos + new Vector3Int(-1, 0, 0);
                        goTemp.GetComponent<BasePoint>().OutComming();
                        isMove = true;
                    }
                }
                break;
        }
    }
}
