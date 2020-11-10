using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransportationWire : TransportationBlock
{
    public TileBase brush;
    TileBase old;
    protected override void StartIn(){
        old = tileMap.GetTile(currentPos);
    }
    protected override void StartMove(){
        tileMap.SetTile(currentPos,old);
    }
    protected override void EndMove(){
        old = tileMap.GetTile(currentPos);
        tileMap.SetTile(currentPos,brush);
    }
}
