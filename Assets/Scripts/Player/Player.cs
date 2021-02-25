using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;

public class Player : Character
{
    public bool invert = false;
    public GameObject deathPlayer;
    Action<object> action;
    Task t1;

    void Awake()
    {
        Camera.main.GetComponent<MoveCamera>().SetTarget(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            var distMove = speed * Time.deltaTime;
            Vector3 oldPos = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, nextPos, distMove);
            if (transform.position.Equals(nextPos))
            {
                if(nextNextPos.z==0){
                    if (nextPos-currentPos==nextNextPos-nextPos){
                        float dist = distMove - Vector3.Distance(oldPos,nextPos);
                        Vector3 vector3Dist=nextPos-currentPos;
                        transform.position += vector3Dist*dist;
                    }

                }

                currentPos = nextPos;
                nextPos = nextNextPos;

                
                //bp.InComming(backPos,true);
                //nextPos = bp.NextPos(backPos);
                if (nextPos.z == 0)
                {
                    ThreadNextPoint();
                    backPos = currentPos;
                    var bp = tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>();
                    bp.InComming(backPos,true);
                    bp.OutComming(true);
                    AnimatedEye();
                }
                else
                {
                    var bp = tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>();
                    bp.InComming(backPos,true);
                    isMove = false;
                    AnimatedStopMove();
                }
            }
        }
    }

    public override void returnBack()
    {
        if (isMove)
        {
            Vector3Int temp = backPos;
            currentPos = nextPos;
            backPos = nextPos;
            nextPos = temp;
            ThreadNextPoint();
        }
    }

    public void ThreadNextPoint()
    {
        Invoke("NextNextPoint",0.001f);
    }

    public void NextNextPoint(){
        try{
        var bp = tileMap.GetInstantiatedObject(nextPos).GetComponent<BasePoint>();
        nextNextPos = bp.NextPos(currentPos);
        }
        catch(Exception ex){
            nextNextPos = new Vector3Int(0,0,1);
        }
    }

    public void Swipe(int rot)
    {
        if (isMove) return;

        if (invert) rot = (rot + 2) % 4;

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
                        ThreadNextPoint();
                        tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
                        AnimatedStartMove();
                        AnimatedEye();
                        ScriptManager.objectManager.moveSizeCamera.zoomIn();
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
                        ThreadNextPoint();
                        tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
                        AnimatedStartMove();
                        AnimatedEye();
                        ScriptManager.objectManager.moveSizeCamera.zoomIn();
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
                        ThreadNextPoint();
                        tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
                        AnimatedStartMove();
                        AnimatedEye();
                        ScriptManager.objectManager.moveSizeCamera.zoomIn();
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
                        ThreadNextPoint();
                        tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
                        AnimatedStartMove();
                        AnimatedEye();
                        ScriptManager.objectManager.moveSizeCamera.zoomIn();
                        isMove = true;
                    }
                }
                break;
        }
    }

    public override void Die()
    {
        Handheld.Vibrate();
        Instantiate(deathPS, transform.position, Quaternion.Euler(70, 0, 0));
        gameObject.AddComponent<RestartAfterDeath>();
        ScriptManager.objectManager.AllCharacter.Remove(gameObject);
        Destroy(gameObject.GetComponent<Player>());
    }
}
