using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPoint : EnabledPoint
{
    public Vector3Int direct;
    public SpriteRenderer button;

    void Awake(){
        button.color = new Color(1,1,1,1f);
    }

    public override void InComming(Vector3Int backPos, bool activPoint)
    {
        Debug.Log("In");
    }

    public override Vector3Int NextPos(Vector3Int backPos)
    {
        if (activ)
        {
            GameObject goT = tileMap.GetInstantiatedObject(pos + direct);
            if (goT != null)
            {
                if (goT.GetComponent<BasePoint>())
                {
                    return pos + direct;
                }
            }
        }

        Vector3Int temp = new Vector3Int(0, 0, 1);

        GameObject goTemp;
        int countCell = 0;
        for (int i = -1; i <= 1; i += 2)
        {

            goTemp = tileMap.GetInstantiatedObject(pos + new Vector3Int(i, 0, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    countCell++;
                    if (!backPos.Equals(pos + new Vector3Int(i, 0, 0)))
                    {
                        temp = pos + new Vector3Int(i, 0, 0);
                    }
                }
            }

            goTemp = tileMap.GetInstantiatedObject(pos + new Vector3Int(0, i, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    countCell++;
                    if (!backPos.Equals(pos + new Vector3Int(0, i, 0)))
                    {
                        temp = pos + new Vector3Int(0, i, 0);
                    }
                }
            }

        }

        if (countCell == 2)
        {
            return temp;
        }
        else return new Vector3Int(0, 0, 1);
    }

    public override void SetActiv(bool activ){
        if (this.activ==activ) return;
        this.activ=activ;
        gameObject.GetComponent<ActivElement>().WireActivAll(activ);
        if (activ) button.color = new Color(1,0,0,1);
        else button.color = new Color(1,1,1,1f);
    }

}
