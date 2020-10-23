using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class EnabledPoint : BasePoint
{
    public SpriteRenderer button;
    protected bool activ=false;
    public void SetActiv(bool activ){
        this.activ=activ;
        if (activ) button.color = Color.red;
        else button.color = Color.white;
    }

    public List<Vector3Int> searchWire(Tilemap map)
    {
        List<Vector3Int> tempList = new List<Vector3Int>();
        if (map.GetTile(pos))
        {
            int number = 0;
            tempList.Add((Vector3Int)pos);
            while (number < tempList.Count)
            {
                for (int i = -1; i <= 1; i += 2)
                {
                    if (map.GetTile(tempList[number] + new Vector3Int(i, 0, 0)) && !tempList.Contains(tempList[number] + new Vector3Int(i, 0, 0)))
                    {
                        tempList.Add(tempList[number] + new Vector3Int(i, 0, 0));
                    }
                    if (map.GetTile(tempList[number] + new Vector3Int(0, i, 0)) && !tempList.Contains(tempList[number] + new Vector3Int(0, i, 0)))
                    {
                        tempList.Add(tempList[number] + new Vector3Int(0, i, 0));
                    }
                }
                number++;
            }
        }
        return tempList;
    }

    public List<EnabledPoint> searchPoint(List<Vector3Int> list, Tilemap map){
        List<EnabledPoint> tempList = new List<EnabledPoint>();
        foreach (Vector3Int go in list){
            GameObject point = map.GetInstantiatedObject(go);
            if (point){
                if (point.GetComponent<EnabledPoint>()){
                    tempList.Add(point.GetComponent<EnabledPoint>());
                }
            }
        }
        return tempList;
    }

    public void OnOffWire(Tilemap map, List<Vector3Int> wire, List<EnabledPoint> enabledPoint)
    {
        if (activ)
        {
            foreach(Vector3Int posWire in wire){
                map.SetColor(posWire, Color.red);
            }
        }
        else
        {
            foreach(Vector3Int posWire in wire){
                map.SetColor(posWire, Color.white);
            }
        }
        foreach(EnabledPoint point in enabledPoint){
                point.SetActiv(activ);
        }
    }  
}
