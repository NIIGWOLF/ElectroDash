using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PanelAnimation : MonoBehaviour
{
    public Vector2 targetPosition;
    public Vector2 startPosition;
    float speed = 0.5f;
    public void GoToTarget(){
        gameObject.GetComponent<RectTransform>().DOAnchorPos(targetPosition, speed);
    }
    public void GoBack(){
        gameObject.GetComponent<RectTransform>().DOAnchorPos(startPosition, speed);
    }

}
