using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchPoint : BasePoint
{
    public bool activ=false;
    protected Tilemap tilemapRedWire;
    protected List<Vector2Int> spritesRedWire;

    public virtual void Start()
    {
        pos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        tilemapRedWire = ScriptManager.objectManager.tilemapRedWire;
    }
    public override Vector3Int InComming(Vector3Int backPos)
    {
        Debug.Log("In");
        activ=!activ;
        OnOffWire();
        return NextPos(backPos);
    }

    private void OnOffWire(){
        if (activ)
            tilemapRedWire.SetColor(pos,Color.white);
            else tilemapRedWire.SetColor(pos,Color.red);
    }

    private List<Vector2Int> searchWire(Tilemap map){
        List<Vector2Int> tempList = new List<Vector2Int>();
        return null;
    }
}
