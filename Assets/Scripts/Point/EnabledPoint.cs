using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class EnabledPoint : BasePoint
{
    public SpriteRenderer button;
    protected bool activ=false;
    public virtual void SetActiv(bool activ){
        if (this.activ==activ) return;
        this.activ=activ;
        gameObject.GetComponent<ActivElement>().WireActivAll(activ);
        if (activ) button.color = Color.red;
        else button.color = Color.white;
    }

    public bool GetActiv(){
        return activ;
    }
}
