using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InvertGenerator : BaseGenerator
{
    public GameObject propeler;
    public SpriteRenderer topButton;
    public SpriteRenderer botButton;
    public SpriteRenderer centerButton;
    public GameObject barier;


    Sequence seq;

    protected override void Visual()
    {
        if (propeler.transform.eulerAngles == new Vector3(0, 0, -360)) propeler.transform.eulerAngles = new Vector3(0, 0, 0);
        if (activ)
        {
            centerButton.color = Color.red;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(propeler.transform.DORotate(propeler.transform.eulerAngles - new Vector3(0, 0, 90), 0.5f));
            sequence.OnComplete(competeTurn);
        }
        else
        {
            centerButton.color = Color.white;
        }
    }

    void competeTurn()
    {
        if (activ)
        {
            if (topButton.color == Color.red)
            {
                topButton.color = Color.white;
                botButton.color = Color.red;
            }
            else
            {
                topButton.color = Color.red;
                botButton.color = Color.white;
            }
            Visual();
        }
        else
        {
            topButton.color = Color.white;
            botButton.color = Color.white;
            centerButton.color = Color.white;
        }
    }

    protected override void Generate()
    {
        if (activ)
        {
            seq.Kill();
            seq = DOTween.Sequence();
            seq.Append(barier.transform.DOScale(new Vector3(15, 15, 0), 0.75f));
        }
        else{
            seq.Kill();
            seq = DOTween.Sequence();
            seq.Append(barier.transform.DOScale(new Vector3(0, 0, 0), 0.75f));
        }
    }
}
