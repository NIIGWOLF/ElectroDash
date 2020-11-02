using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransportationWire : TransportationBlock
{
    Tilemap wireTilemap;
    TileBase brush;
    TileBase old;
    protected override void StartIn(){
        wireTilemap = ScriptManager.objectManager.tilemapRedWire;
        brush = ScriptManager.brushManager.wireRed;
    }
    protected override void StartMove(){
        wireTilemap.SetTile(currentPos,old);
    }
    protected override void EndMove(){
        old = wireTilemap.GetTile(currentPos);
        wireTilemap.SetTile(currentPos,brush);
    }
}
