using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchPoint : EnabledPoint
{
    public override Vector3Int InComming(Vector3Int backPos, bool activPoint)
    {
        //Debug.Log("In");
        if (activPoint)
        {
            SetActiv(!activ);
        }
        return NextPos(backPos);
    }


}
