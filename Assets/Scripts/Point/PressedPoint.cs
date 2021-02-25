using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PressedPoint : EnabledPoint
{
    public SpriteRenderer button;
    public bool active=false;

    public override void Start()
    {
        pos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        SetActiv(active);
    }
    public override void InComming(Vector3Int backPos, bool activPoint)
    {
        Debug.Log("In");
        if (activPoint)
        {
            SetActiv(!activ);
        }
    }

    public override void OutComming(bool activPoint)
    {
        if (activPoint)
        {
            SetActiv(!activ);
        }
        Debug.Log("Out");
    }

    public override void SetActiv(bool activ){
        if (this.activ==activ) return;
        this.activ=activ;
        gameObject.GetComponent<ActivElement>().WireActivAll(activ);
        if (activ) button.color = Color.red;
        else button.color = Color.white;
    }
}
