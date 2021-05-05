using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveSizeCamera : MonoBehaviour
{
    Sequence seq;
    Camera cam;
    float defaultSize = 3.2f;
    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    public void zoomIn(){
        if (cam.orthographicSize==defaultSize) return;
        seq.Kill();
        seq = DOTween.Sequence();
        seq.Append(cam.DOOrthoSize(defaultSize,0.25f));
    }
    public void zoomOut(float valueZoom){
        if (cam.orthographicSize==valueZoom) return;
        seq.Kill();
        seq = DOTween.Sequence();
        seq.Append(cam.DOOrthoSize(valueZoom,0.25f));
    }
}
