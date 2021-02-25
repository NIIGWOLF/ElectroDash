using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPoint : BasePoint
{
    public override Vector3Int InComming(Vector3Int backPos, bool activPoint)
    {
        //Debug.Log("In");
        return new Vector3Int(0, 0, 1);
    }
}
