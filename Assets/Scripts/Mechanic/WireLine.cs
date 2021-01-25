using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WireLine : MonoBehaviour
{
    bool activ;
    Sequence sequence;
    ActivElement element1;
    ActivElement element2;
    void Start()
    {
        transform.localScale = new Vector3(1, 0, 1);
    }

    public void SetElement(ActivElement element1, ActivElement element2){
        this.element1 = element1;
        this.element2 = element2;
    }

    public void SetActiv(bool activ)
    {
        if (this.activ == activ) return;
        this.activ = activ;
        if (activ)
        {
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(transform.DOScaleY(1f, 0.5f));
            sequence.Append(transform.DOShakeScale(5f, new Vector3(0, 0.2f, 0), 1, 10, true));
        }
        else
        {
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(transform.DOScaleY(0, 0.5f));
        }
    }

    public void DeleteWire()
    {
        if (activ)
        {
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(transform.DOScaleY(0, 0.5f));
            sequence.OnComplete(CompleteDelete);
        }
        else
        {
            CompleteDelete();
        }
    }

    public void FastDeleteWire()
    {
        if (activ)
        {
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(transform.DOScaleY(0, 0.15f));
            sequence.OnComplete(CompleteDelete);
        }
        else
        {
            CompleteDelete();
        }
    }

    public void CompleteDelete()
    {
        ScriptManager.wireManager.Wires.Remove(ScriptManager.wireManager.getKey(element1,element2));
        Destroy(gameObject);
    }
}
