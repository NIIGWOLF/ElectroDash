using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchPoint : EnabledPoint
{
    protected Tilemap tilemapRedWire;
    protected List<Vector3Int> spritesRedWire;
    protected List<EnabledPoint> pointEnabledRedWire;

    public override void Start()
    {
        pos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        tilemapRedWire = ScriptManager.objectManager.tilemapRedWire;
    }
    public override Vector3Int InComming(Vector3Int backPos)
    {
        Debug.Log("In");
        SetActiv(!activ);
        spritesRedWire = searchWire(tilemapRedWire);
        pointEnabledRedWire = searchPoint(spritesRedWire,tileMap);
        OnOffWire(tilemapRedWire,spritesRedWire,pointEnabledRedWire);
        return NextPos(backPos);
    }

     
}
