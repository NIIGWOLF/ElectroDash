using UnityEngine;
using UnityEngine.Tilemaps;

public class TransportationPlayer : TransportationBlock
{
    public TileBase brush;
    TileBase old;
    public GameObject block;
    protected GameObject character = null;
    protected override void StartIn()
    {
        block.GetComponent<SpriteRenderer>().sprite = ((RuleTile)brush).m_DefaultSprite;
        old = tileMap.GetTile(currentPos);
        tileMap.SetTile(currentPos, brush);
    }
    protected override void StartMove()
    {
        foreach (GameObject goch in ScriptManager.objectManager.AllCharacter)
        {
            var ch = goch.GetComponent<Character>();
            if (ch.CurrentPos == currentPos && ch.NextPos == new Vector3Int(0, 0, 1))
            {
                ch.Transportation(true);
                character = goch;
                character.transform.parent = transform;
            }
        }

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

        if (character != null)
        {
            character.GetComponent<Character>().Transportation(false);
            character.GetComponent<Character>().CurrentPos = currentPos;
            character.transform.parent = null;

        }
        character = null;
    }
}
