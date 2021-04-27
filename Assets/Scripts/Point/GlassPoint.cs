using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GlassPoint : BasePoint
{
    public GameObject block;
    public Sprite destroy1;
    public Sprite destroy2;
    public GameObject PSDestroy;
    public bool isDestroy = false;
    public override void OutComming(bool activPoint)
    {
        isDestroy=true;
        DeletePoint();
    }

    void DeletePoint(){
        StaticManager.levelManager.soundsManager.GlassSound.Play();
        tileMap.SetColor(pos,new Color(1,1,1,0));
        Sequence sequence= DOTween.Sequence();
        sequence.Append(block.transform.DOShakePosition(0.25f, new Vector3(0.05f,0.05f,0),100,90,false,true));
        sequence.OnComplete(stage1);
    }

    void stage1(){
        block.GetComponent<SpriteRenderer>().sprite=destroy1;
        Sequence sequence= DOTween.Sequence();
        sequence.Append(block.transform.DOShakePosition(0.25f, new Vector3(0.05f,0.05f,0),100,90,false,true));
        sequence.OnComplete(stage2);
    }

    void stage2(){
        block.GetComponent<SpriteRenderer>().sprite=destroy2;
        Sequence sequence= DOTween.Sequence();
        sequence.Append(block.transform.DOShakePosition(0.25f, new Vector3(0.05f,0.05f,0),100,90,false,true));
        sequence.OnComplete(stage3);
    }

    void stage3(){
        Instantiate(PSDestroy,transform.position,Quaternion.identity);
        tileMap.SetTile(pos,null);
        Destroy(gameObject);
    }
}
