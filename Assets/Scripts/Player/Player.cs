using UnityEngine;

public class Player : Character
{
    public bool invert=false;

    void Awake(){
        Camera.main.GetComponent<MoveCamera>().SetTarget(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            if (transform.position.Equals(nextPos))
            {
                currentPos = nextPos;
                nextPos = tileMap.GetInstantiatedObject(nextPos).GetComponent<BasePoint>().InComming(backPos,true);
                if (nextPos.z == 0)
                {
                    backPos = currentPos;
                    tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
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
        if (isMove) return;

        if (invert) rot=(rot+2)%4;

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
                        tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
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
                        tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
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
                        tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
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
                        tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
                        isMove = true;
                    }
                }
                break;
        }
    }

}
