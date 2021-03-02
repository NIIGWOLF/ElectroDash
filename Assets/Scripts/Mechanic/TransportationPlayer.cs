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
        //old = tileMap.GetTile(currentPos);
        tileMap.SetTile(currentPos, brush);
    }
    protected override void StartMove()
    {
        foreach(GameObject go in ScriptManager.objectManager.AllCharacter){
            var ch = go.GetComponent<Character>();
            if (ch.CurrentPos==currentPos){
                ch.Transportation(true);
                character=go;
                character.transform.parent=transform;
            }
        }

        tileMap.SetTile(currentPos, old);
    }
    protected override void EndMove()
    {
        old = tileMap.GetTile(currentPos);
        tileMap.SetTile(currentPos, brush);
        GameObject go = tileMap.GetInstantiatedObject(currentPos);
        if (go)
        {
            if (go.GetComponent<StartDeathPS>()){
                go.GetComponent<StartDeathPS>().enabled=true;
            }
            if (go.GetComponent<GenerateWire>())
            {
                go.GetComponent<GenerateWire>().isNew=true;
            }
            if (go.GetComponent<ActivElement>())
            {
                go.GetComponent<ActivElement>().fastDeleteWire=true;
            }
        }

        if (character!=null){
            character.GetComponent<Character>().Transportation(false);
            character.GetComponent<Character>().CurrentPos=currentPos;
            character.transform.parent=null;
            
        }
        character=null;
    }
}
