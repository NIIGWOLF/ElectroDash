using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveSizeCamera : MonoBehaviour
{
    Sequence seq;
    Camera cam;
    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    public void zoomIn(){
        if (cam.orthographicSize==2.5f) return;
        seq.Kill();
        seq = DOTween.Sequence();
        seq.Append(cam.DOOrthoSize(2.5f,0.25f));
    }
    public void zoomOut(){
        if (cam.orthographicSize==6f) return;
        seq.Kill();
        seq = DOTween.Sequence();
        seq.Append(cam.DOOrthoSize(6f,0.25f));
    }
}
