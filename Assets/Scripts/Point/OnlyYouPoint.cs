using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyYouPoint : BasePoint
{
    public override Vector3Int InComming(Vector3Int backPos, bool activPoint, GameObject character)
    {
        //Debug.Log("In");
        if (!character.GetComponent<Player>())
        return backPos;
        else
        return NextPos(backPos);
    }
}
