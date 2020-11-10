﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class EnabledPoint : BasePoint
{
    protected bool activ=false;
    public virtual void SetActiv(bool activ){
        if (this.activ==activ) return;
        this.activ=activ;
        gameObject.GetComponent<ActivElement>().WireActivAll(activ);
    }

    public bool GetActiv(){
        return activ;
    }
}
