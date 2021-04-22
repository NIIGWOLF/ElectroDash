using UnityEngine;


public class Player : Character
{
    public bool invert=false;
    public GameObject deathPlayer;

    void Awake(){
        Camera.main.GetComponent<MoveCamera>().SetTarget(gameObject);
        ScriptManager.player = gameObject;
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
                currentPos = nextPos;
                nextPos = tileMap.GetInstantiatedObject(nextPos).GetComponent<BasePoint>().InComming(backPos,true,gameObject);
                if (nextPos.z == 0)
                {
                    //Debug.Log(backPos+"|"+currentPos+"|"+nextPos);
                    if (nextPos-currentPos==currentPos-backPos){
                        float dist = distMove - Vector3.Distance(oldPos,currentPos);
                        Vector3 vector3Dist=nextPos-currentPos;
                        transform.position += vector3Dist*dist;
                    }
                    backPos = currentPos;
                    tileMap.GetInstantiatedObject(currentPos).GetComponent<BasePoint>().OutComming(true);
                    AnimatedEye();
                }
                else
                {
                    isMove = false;
                    enterBarier = false;
                    AnimatedStopMove();
                }
            }
        }else{
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) Swipe(0);
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) Swipe(1);
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) Swipe(2);
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) Swipe(3);

        }
    }

    public void Swipe(int rot)
    {
        StaticManager.levelManager.soundsManager.SwipeSound.Play();
        if (isMove) return;
        if (isTransportation) return;

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

    public override void Transportation(bool transportation){
        isTransportation=transportation;
    }

    public override void Die()
    {
        ScriptManager.objectManager.timer.activ = false;
        StaticManager.levelManager.soundsManager.DeadSound.Play();
        Handheld.Vibrate();
        Instantiate(deathPS,transform.position,Quaternion.Euler(70,0,0));
        gameObject.AddComponent<RestartAfterDeath>();
        Destroy(gameObject.GetComponent<Player>());
    }
}
