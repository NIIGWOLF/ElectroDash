using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerGenerator : BaseGenerator
{
    public GameObject lines;
    public SpriteRenderer centerButton;
    public GameObject barier;
    public ParticleSystem ps;


    Sequence seq;

    protected override void Visual()
    {
        if (lines.transform.localPosition != Vector3.zero) lines.transform.localPosition = Vector3.zero;
        if (activ)
        {
            if (!ps.isPlaying) ps.Play();
            centerButton.color = Color.red;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(lines.transform.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0), 100, 90, false, true));
            sequence.OnComplete(competeShake);
        }
        else
        {
            centerButton.color = Color.white;
            ps.Stop();
        }
    }

    void competeShake()
    {
        if (activ)
        {
            Visual();
        }
        else
        {
            centerButton.color = Color.white;
            ps.Stop();
        }
    }

    protected override void Generate()
    {
        if (activ)
        {
            StaticManager.levelManager.soundsManager.PowerOnSound.Play();
            seq.Kill();
            seq = DOTween.Sequence();
            seq.Append(barier.transform.DOScale(new Vector3(2, 2, 0), 0.75f));
        }
        else{
            StaticManager.levelManager.soundsManager.PowerOffSound.Play();
            seq.Kill();
            seq = DOTween.Sequence();
            seq.Append(barier.transform.DOScale(new Vector3(0, 0, 0), 0.75f));
        }
    }
}
