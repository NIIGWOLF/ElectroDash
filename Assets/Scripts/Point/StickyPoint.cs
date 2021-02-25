using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPoint : BasePoint
{
    public override Vector3Int NextPos(Vector3Int backPos)
    {
        //Debug.Log("In");
        return new Vector3Int(0, 0, 1);
    }
}
