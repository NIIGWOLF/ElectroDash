using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewMoving : MonoBehaviour
{
    public Vector3 rightDown = new Vector3(150, -150, 0);
    public Vector3 rightUp = new Vector3(150, 150, 0);
    public Vector3 leftUp = new Vector3(-150, 150, 0);
    public Vector3 leftDown = new Vector3(-150, -150, 0);
    public float speed = 1.2f;
    private int flag = 0;
    void Update()
    {
        SquareMoving();
    }
    private void SquareMoving()
    {
        switch (flag)
        {
            case 0:
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, rightUp, speed*Time.deltaTime);
                if (gameObject.transform.localPosition == rightUp) flag = 1;
                break;
            case 1:
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, leftUp, speed*Time.deltaTime);
                if (gameObject.transform.localPosition == leftUp) flag = 2;
                break;
            case 2:
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, leftDown, speed*Time.deltaTime);
                if (gameObject.transform.localPosition == leftDown) flag = 3;
                break;
            case 3:
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, rightDown, speed*Time.deltaTime);
                if (gameObject.transform.localPosition == rightDown) flag = 0;
                break;
            default:
                break;
        }
    }
}
