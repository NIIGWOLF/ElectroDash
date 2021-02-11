using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    Sequence seq;

    void Start()
    {     
        Visual();
    }

    void Visual(){
        transform.Rotate(Vector3.zero,Space.World);
        transform.DORotate(new Vector3(0,360,0),5,RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(Visual);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Coin");
        CountData.Instance.amountData.coins+=1;
        Debug.Log(CountData.Instance.amountData.coins);
        gameObject.active=false;
    }
}
