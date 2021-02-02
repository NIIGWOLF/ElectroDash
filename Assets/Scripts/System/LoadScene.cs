using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Color white;
    public Color black;
    public Color imageBlack;
    void OnEnable(){
        gameObject.GetComponent<Image>().DOColor(white, 0.6f);
        foreach (var component in gameObject.GetComponentsInChildren<Image>()){
            component.DOColor(white, 0.6f);
        }
        gameObject.GetComponentsInChildren<RectTransform>()[1].DOScale(new Vector3(1.5f,1.5f,1.5f),0.6f);
       Invoke("UNactive",0.61f);
    }
   
    void UNactive(){
        gameObject.SetActive(false);
    }
    public void BeforeNewScene(){
        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().DOColor(Color.black, 0.6f);
        int i=0;
        foreach (var component in gameObject.GetComponentsInChildren<Image>()){
           if (i!=0)
            component.DOColor(imageBlack, 0.6f);
            i++;
        }
        gameObject.GetComponentsInChildren<RectTransform>()[1].DOScale(new Vector3(3f,3f,3f),0.6f);
    }
    
}
