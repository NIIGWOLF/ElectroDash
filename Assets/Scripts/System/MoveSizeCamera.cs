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
    public void zoomOut(float valueZoom){
        if (cam.orthographicSize==valueZoom) return;
        seq.Kill();
        seq = DOTween.Sequence();
        seq.Append(cam.DOOrthoSize(valueZoom,0.25f));
    }
}
