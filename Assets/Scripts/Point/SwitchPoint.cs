using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchPoint : EnabledPoint
{
    public SpriteRenderer button;
    public bool active=false;

    public override void Start()
    {
        pos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        SetActiv(active);
    }
    public override Vector3Int InComming(Vector3Int backPos, bool activPoint, GameObject character)
    {
        //Debug.Log("In");
        if (activPoint)
        {
            SetActiv(!activ);
        }
        return NextPos(backPos);
    }

    public override void SetActiv(bool activ)
    {
        if (this.activ == activ) return;
        this.activ = activ;
        gameObject.GetComponent<ActivElement>().WireActivAll(activ);
        if (activ) button.color = Color.red;
        else button.color = Color.white;
    }

}
