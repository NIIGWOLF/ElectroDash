using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeButtonColor : MonoBehaviour
{
    public Color selectedColor;
    public Color normalColor;
    public void ChangeColor(){
        gameObject.GetComponent<Image>().color = selectedColor;
    }
    public void NormalColor(){
        gameObject.GetComponent<Image>().color = normalColor;
    }
}
