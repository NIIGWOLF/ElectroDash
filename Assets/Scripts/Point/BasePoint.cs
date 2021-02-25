using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BasePoint : MonoBehaviour
{
    protected Vector3Int pos;
    protected Tilemap tileMap;
    public virtual void Start()
    {
        pos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
    }
    public virtual void InComming(Vector3Int backPos, bool activPoint)
    {
        //Debug.Log("In");
        //return NextPos(backPos);
    }

    public virtual void OutComming(bool activPoint)
    {
        //Debug.Log("Out");
    }

    public virtual Vector3Int NextPos(Vector3Int backPos)
    {
        Vector3Int temp = new Vector3Int(0, 0, 1);
        var tileMap = ScriptManager.objectManager.tilemap;

        GameObject goTemp;
        int countCell = 0;
        for (int i = -1; i <= 1; i += 2)
        {

            goTemp = tileMap.GetInstantiatedObject(pos + new Vector3Int(i, 0, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    countCell++;
                    if (!backPos.Equals(pos + new Vector3Int(i, 0, 0)))
                    {
                        temp = pos + new Vector3Int(i, 0, 0);
                    }
                }
            }

            goTemp = tileMap.GetInstantiatedObject(pos + new Vector3Int(0, i, 0));
            if (goTemp != null)
            {
                if (goTemp.GetComponent<BasePoint>())
                {
                    countCell++;
                    if (!backPos.Equals(pos + new Vector3Int(0, i, 0)))
                    {
                        temp = pos + new Vector3Int(0, i, 0);
                    }
                }
            }

        }

        if (countCell == 2)
        {
            return temp;
        }
        else return new Vector3Int(0, 0, 1);
    }

    void OnDestroy(){
        if (!ScriptManager.objectManager.activStartDaethPS) return;
        foreach(GameObject go in ScriptManager.objectManager.AllCharacter){
            var character = go.GetComponent<Character>();
            if (character.CurrentPos==pos || character.NextPos==pos){
                character.Die(pos);
                Debug.Log("isDie");
            }
        }
    }

}
