using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransportationWire : TransportationBlock
{
    public TileBase brush;
    TileBase old;
    protected override void StartIn()
    {
        old = tileMap.GetTile(currentPos);
    }
    protected override void StartMove()
    {
        tileMap.SetTile(currentPos, old);
        GameObject go = tileMap.GetInstantiatedObject(currentPos);
        if (go)
            if (go.GetComponent<GenerateWire>())
            {
                go.GetComponent<GenerateWire>().isNew=true;
            }
    }
    protected override void EndMove()
    {
        old = tileMap.GetTile(currentPos);
        tileMap.SetTile(currentPos, brush);
        GameObject go = tileMap.GetInstantiatedObject(currentPos);
        if (go)
            if (go.GetComponent<GenerateWire>())
            {
                go.GetComponent<GenerateWire>().isNew=true;
            }
    }
}
