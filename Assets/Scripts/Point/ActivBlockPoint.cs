using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivBlockPoint : ActivPoint
{
    //public SpriteRenderer button;
    public Sprite Green;
    public Sprite Grey;

    void Awake(){
        //button.color = new Color(1,1,1,1f);
    }

    public override Vector3Int InComming(Vector3Int backPos, bool activPoint, GameObject character)
    {
        if (activ)
        {
            return NextPos(backPos);
        }
        else{
            return backPos;
        }
        
    }

    public override void SetActiv(bool activ){
        if (this.activ==activ) return;
        this.activ=activ;
        gameObject.GetComponent<ActivElement>().WireActivAll(activ);
        if (activ) {
            //button.color = new Color(1,0,0,1);
            gameObject.GetComponent<SpriteRenderer>().sprite=Green;
        }
        else {
            //button.color = new Color(1,1,1,1f);
            gameObject.GetComponent<SpriteRenderer>().sprite=Grey;
        }
    }
}
