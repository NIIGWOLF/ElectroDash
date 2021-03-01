using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DinamitPoint : BasePoint
{
    public GameObject block;
    public GameObject PSDestroy;
    public override void OutComming(bool activPoint)
    {
        DeletePoint();
    }

    void DeletePoint()
    {
        tileMap.SetColor(pos, new Color(1, 1, 1, 0));
        Sequence sequence = DOTween.Sequence();
        sequence.Append(block.transform.DOShakePosition(1f, new Vector3(0.1f, 0.1f, 0), 100, 90, false, true));
        sequence.OnComplete(Complete);
    }

    void Complete()
    {
        StaticManager.levelManager.soundsManager.ExplosionSound.Play();

        Instantiate(PSDestroy,transform.position,Quaternion.identity);
        tileMap.SetTile(pos, null);
        tileMap.SetTile(pos + Vector3Int.up, null);
        tileMap.SetTile(pos + Vector3Int.down, null);
        tileMap.SetTile(pos + Vector3Int.left, null);
        tileMap.SetTile(pos + Vector3Int.right, null);

        GameObject goTemp;
        for (int i = -1; i <= 1; i += 2)
        {

            goTemp = tileMap.GetInstantiatedObject(pos + new Vector3Int(i, 0, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    Destroy(goTemp.gameObject);
                }
            }
            tileMap.SetTile(pos + new Vector3Int(i, 0, 0), null);

            goTemp = tileMap.GetInstantiatedObject(pos + new Vector3Int(0, i, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    Destroy(goTemp.gameObject);
                }
            }
            tileMap.SetTile(pos + new Vector3Int(0, i, 0), null);

        }
        Destroy(gameObject);
    }
}
