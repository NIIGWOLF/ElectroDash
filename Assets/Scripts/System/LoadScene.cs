using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    
     void Start(){
        print("UnActive");
        foreach (var component in gameObject.GetComponentsInChildren<Image>()){
            component.DOFade(0, 0.6f);
        }
        gameObject.GetComponentsInChildren<RectTransform>()[1].DOScale(new Vector3(1.5f,1.5f,1.5f),0.6f).OnComplete(UNactive);

      
    }
   
    public void UNactive(){
        gameObject.SetActive(false);
        
    }
    public void BeforeNewScene(){
        gameObject.SetActive(true);
        
        foreach (var component in gameObject.GetComponentsInChildren<Image>()){
          
            component.DOFade(1, 0.6f);
            
        }
        gameObject.GetComponentsInChildren<RectTransform>()[1].DOScale(new Vector3(3f,3f,3f),0.6f);
        
    }
    
}
