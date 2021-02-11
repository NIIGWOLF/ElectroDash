using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : BasePoint
{
    public override Vector3Int InComming(Vector3Int backPos, bool activPoint)
    {
        StaticManager.levelManager.levelCompleteCanvas.active=true;
        return NextPos(backPos);
    }
}
