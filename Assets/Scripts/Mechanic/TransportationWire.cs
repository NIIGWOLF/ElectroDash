using UnityEngine;
using UnityEngine.Tilemaps;

public class TransportationWire : TransportationBlock
{
    public TileBase brush;
    TileBase old;
    public GameObject block;
    protected override void StartIn()
    {
        block.GetComponent<SpriteRenderer>().sprite = ((RuleTile)brush).m_DefaultSprite;
        old = tileMap.GetTile(currentPos);
        tileMap.SetTile(currentPos, brush);
    }
    protected override void StartMove()
    {
        GameObject go = tileMap.GetInstantiatedObject(currentPos);
        if (go)
        {
            if (go.GetComponent<GlassPoint>())
            {
                if (go.GetComponent<GlassPoint>().isDestroy)
                {
                    brush = null;
                    block.GetComponent<SpriteRenderer>().sprite = null;
                }
                else
                {
                    brush = tileMap.GetTile(currentPos);
                    block.GetComponent<SpriteRenderer>().sprite = ((RuleTile)brush).m_DefaultSprite;
                }
            }
            else
            {
                brush = tileMap.GetTile(currentPos);
                block.GetComponent<SpriteRenderer>().sprite = ((RuleTile)brush).m_DefaultSprite;
            }
        }
        else
        {
            brush = null;
            block.GetComponent<SpriteRenderer>().sprite = null;
        }

        if (go)
        {
            if (!go.GetComponent<GlassPoint>())
            {
                tileMap.SetTile(currentPos, old);
            }
            else
            {
                if (!go.GetComponent<GlassPoint>().isDestroy)
                    tileMap.SetTile(currentPos, old);
            }
        }
        go = tileMap.GetInstantiatedObject(currentPos);
        if (go)
            if (go.GetComponent<GenerateWire>())
            {
                go.GetComponent<GenerateWire>().isNew = true;
            }
    }
    protected override void EndMove()
    {
        old = tileMap.GetTile(currentPos);
        tileMap.SetTile(currentPos, brush);
        block.GetComponent<SpriteRenderer>().sprite = null;
        GameObject go = tileMap.GetInstantiatedObject(currentPos);
        if (go)
        {
            if (go.GetComponent<StartDeathPS>())
            {
                go.GetComponent<StartDeathPS>().enabled = true;
            }
            if (go.GetComponent<GenerateWire>())
            {
                go.GetComponent<GenerateWire>().isNew = true;
            }
            if (go.GetComponent<ActivElement>())
            {
                go.GetComponent<ActivElement>().fastDeleteWire = true;
            }
        }
    }
}
