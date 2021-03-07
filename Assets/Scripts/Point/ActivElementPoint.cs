using UnityEngine;

public class ActivElementPoint : ActivPoint
{
    public SpriteRenderer button;

    void Awake(){
        button.color = new Color(1,1,1,1f);
    }

    public override void SetActiv(bool activ){
        if (this.activ==activ) return;
        this.activ=activ;
        gameObject.GetComponent<ActivElement>().WireActivAll(activ);
        if (activ) button.color = new Color(1,0,0,1);
        else button.color = new Color(1,1,1,1f);
    }
}
