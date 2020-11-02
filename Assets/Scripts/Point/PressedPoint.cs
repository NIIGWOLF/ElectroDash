using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PressedPoint : EnabledPoint
{
    public override Vector3Int InComming(Vector3Int backPos, bool activPoint)
    {
        Debug.Log("In");
        if (activPoint)
        {
            SetActiv(!activ);
        }
        return NextPos(backPos);
    }

    public override void OutComming(bool activPoint)
    {
        if (activPoint)
        {
            SetActiv(!activ);
        }
        Debug.Log("Out");
    }
}
