using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UseHint : MonoBehaviour
{
    public GameObject simpleHints;
    bool isUsedSimppleHint = false;
    public void useSimpleHint(){
        if (StaticManager.hintData.hint.simpleHint>0 && !isUsedSimppleHint){
        foreach (var component in simpleHints.GetComponentsInChildren<SpriteRenderer>()){
            component.DOFade(0.65f,0.6f);
        }
        foreach (var ps in simpleHints.GetComponentsInChildren<ParticleSystem>()){
            ps.Play();
        }
        StaticManager.hintData.hint.simpleHint--;
        StaticManager.hintData.SaveData();
        StaticManager.levelManager.countSimpleHint.GetComponent<Text>().text = StaticManager.hintData.hint.simpleHint.ToString();
        isUsedSimppleHint = true;
        }

    
    }
}
