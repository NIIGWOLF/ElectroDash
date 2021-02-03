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

    public override Vector3Int InComming(Vector3Int backPos, bool activPoint)
    {
        Debug.Log("In");
        if (activ)
        {
            GameObject goTemp = tileMap.GetInstantiatedObject(pos + direct);
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    return pos + direct;
                }
            }
        }
        return NextPos(backPos);
    }

    public override void SetActiv(bool activ){
        if (this.activ==activ) return;
        this.activ=activ;
        gameObject.GetComponent<ActivElement>().WireActivAll(activ);
        if (activ) button.color = new Color(1,0,0,1);
        else button.color = new Color(1,1,1,1f);
    }

}
