using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    public float kMove = 0.05f; 
    private RawImage image; 
    public Camera myCamera;
    public float kDist=0.2f;


    void Start()
    {
        image = GetComponent<RawImage>();
    }

    void Update()
    {
        image.uvRect = new Rect(((myCamera.transform.position.x*kMove)%1), ((myCamera.transform.position.y*kMove)%1), myCamera.orthographicSize*kDist,myCamera.orthographicSize*kDist);
    }
}
