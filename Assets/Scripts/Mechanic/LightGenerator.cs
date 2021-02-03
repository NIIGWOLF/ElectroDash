using UnityEngine;
using DG.Tweening;

public class LightGenerator : BaseGenerator
{
    public GameObject charge;
    public SpriteRenderer centerButton;
    private GameObject barier = null;
    public SpriteRenderer lamp;
    public ParticleSystem ps;


    private int nextPoint = 1;
    Sequence seq;

    Vector3[] points = {
        new Vector3(0.38f,0.0625f,-0.1f),
        new Vector3(0.42f,0.0625f,-0.1f),
        new Vector3(0.42f,-0.067f,-0.1f),
        new Vector3(0.48f,-0.067f,-0.1f),
        new Vector3(0.48f,-0.3f,-0.1f),
        new Vector3(-0.083f,-0.3f,-0.1f),
        new Vector3(-0.083f,-0.067f,-0.1f),
        new Vector3(0.38f,-0.067f,-0.1f)
        };

    protected override void AfterStart()
    {
        Generate();
    }
    protected override void Visual()
    {
        if (activ)
        {
            if (!ps.isPlaying) ps.Play();
            charge.active=true;
            if (nextPoint>=points.Length) nextPoint=0;
            centerButton.color = Color.red;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(charge.transform.DOLocalMove(points[nextPoint],0.1f,false));
            sequence.OnComplete(competeMove);
            nextPoint++;
        }
        else
        {
            charge.active=false;
            charge.transform.localPosition=points[0];
            centerButton.color = Color.white;
            ps.Stop();
        }
    }

    void competeMove()
    {
        if (activ)
        {
            Visual();
        }
        else
        {
            ps.Stop();
            centerButton.color = Color.white;
        }
    }

    protected override void Generate()
    {
        if (barier==null) barier = ScriptManager.objectManager.BlackBarier;
        if (activ)
        {
            seq.Kill();
            seq = DOTween.Sequence();
            seq.Append(barier.GetComponent<SpriteRenderer>().DOFade(0,0.5f));
            lamp.color = Color.yellow;
        }
        else{
            seq.Kill();
            seq = DOTween.Sequence();
            seq.Append(barier.GetComponent<SpriteRenderer>().DOFade(1,0.5f));
            lamp.color = Color.white;
        }
    }


}
