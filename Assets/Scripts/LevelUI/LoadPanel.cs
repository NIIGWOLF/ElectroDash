using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    [Range(0f,1f)] public float max = 1f;
    [Range(0f,1f)] public float min = 0f;
    void OnEnable(){
       gameObject.GetComponent<Image>().DOFade(max, 1f);
    }
    void OnDisable(){
        gameObject.GetComponent<Image>().DOFade(min, 1f);
    }
   
}
