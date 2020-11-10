using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGenerator : ActivElement
{
    public override void SetActiv(bool activ)
    {
        if (this.activ != activ)
        {
            this.activ = activ;
            Visual();
            Generate();
        }
    }

    protected virtual void  Visual()
    {

    }

    protected virtual void Generate(){

    }


}
