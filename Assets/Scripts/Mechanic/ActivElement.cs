using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActivElement : MonoBehaviour
{
    bool priority = false;
    Tilemap tilemap;
    public List<ActivElement> listElements = new List<ActivElement>();
    Vector3Int currentPos;
    int sizeWire = 7;
    protected bool activ = false;

    protected virtual void Start()
    {
        currentPos = Vector3Int.RoundToInt(transform.position);
        tilemap = ScriptManager.objectManager.tilemap;
        RecheckWire();
        CreateAllWire();
        ActivDetection();
    }

    protected void RecheckWire()
    {
        listElements.Clear();
        for (int i = 1; i < sizeWire; i++) //right
        {
            GameObject point = tilemap.GetInstantiatedObject(currentPos + new Vector3Int(i, 0, 0));
            if (point == null) continue;
            else if (point.GetComponent<ActivElement>())
            {
                AddActivElementList(point.GetComponent<ActivElement>());
                point.GetComponent<ActivElement>().AddActivElementList(this);
            }
            break;
        }
        for (int i = 1; i < sizeWire; i++) //left
        {
            GameObject point = tilemap.GetInstantiatedObject(currentPos + new Vector3Int(-i, 0, 0));
            if (point == null) continue;
            else if (point.GetComponent<ActivElement>())
            {
                AddActivElementList(point.GetComponent<ActivElement>());
                point.GetComponent<ActivElement>().AddActivElementList(this);
            }
            break;
        }
        for (int i = 1; i < sizeWire; i++) //up
        {
            GameObject point = tilemap.GetInstantiatedObject(currentPos + new Vector3Int(0, i, 0));
            if (point == null) continue;
            else if (point.GetComponent<ActivElement>())
            {
                AddActivElementList(point.GetComponent<ActivElement>());
                point.GetComponent<ActivElement>().AddActivElementList(this);
            }
            break;
        }
        for (int i = 1; i < sizeWire; i++) //down
        {
            GameObject point = tilemap.GetInstantiatedObject(currentPos + new Vector3Int(0, -i, 0));
            if (point == null) continue;
            else if (point.GetComponent<ActivElement>())
            {
                AddActivElementList(point.GetComponent<ActivElement>());
                point.GetComponent<ActivElement>().AddActivElementList(this);
            }
            break;
        }
    }

    protected void CreateWire(ActivElement element)
    {
        ScriptManager.wireManager.Wires.Add(ScriptManager.wireManager.getKey(this, element), new WireManager.Wire(this, element));
    }

    protected void CreateAllWire()
    {
        foreach (ActivElement element in listElements)
        {
            if (!ScriptManager.wireManager.Wires.ContainsKey(ScriptManager.wireManager.getKey(this, element)))
            {
                CreateWire(element);
            }
        }
    }

    protected void DeleteWire(ActivElement element)
    {
        var key = ScriptManager.wireManager.getKey(this, element);
        if (ScriptManager.wireManager.Wires.ContainsKey(key))
            ScriptManager.wireManager.Wires[key].wire.GetComponent<WireLine>().DeleteWire();
    }

    public void WireActivAll(bool activ)
    {
        SetActiv(activ);
        if (gameObject.GetComponent<EnabledPoint>()) gameObject.GetComponent<EnabledPoint>().SetActiv(activ);
        foreach (ActivElement element in listElements)
        {
            if (element.GetActiv() != activ)
            {
                element.WireActivAll(activ);
            }
            var key = ScriptManager.wireManager.getKey(this, element);
            if (ScriptManager.wireManager.Wires.ContainsKey(key))
                ScriptManager.wireManager.Wires[key].wire.GetComponent<WireLine>().SetActiv(activ);
        }
    }

    public void WireActiv(bool activ)
    {
        foreach (ActivElement element in listElements)
        {
            ScriptManager.wireManager.Wires[ScriptManager.wireManager.getKey(this, element)].wire.GetComponent<WireLine>().SetActiv(activ);
        }
    }

    public void ActivDetection()
    {
        foreach (ActivElement element in listElements)
        {
            SetActiv(activ | element.GetActiv());
        }
        WireActivAll(activ);
    }

    public bool SearchEnabledPoint()
    {
        bool temp = false;
        if (gameObject.GetComponent<EnabledPoint>()) return true;
        else
        {
            List<ActivElement> list = new List<ActivElement>() { this };
            foreach (ActivElement element in listElements)
            {
                temp = temp | element.SearchEnabledPoint(list);
            }
        }
        return temp;
    }

    public bool SearchEnabledPoint(List<ActivElement> list)
    {
        bool temp = false;
        if (gameObject.GetComponent<EnabledPoint>()) return gameObject.GetComponent<EnabledPoint>().GetActiv();
        else
        {
            foreach (ActivElement element in listElements)
            {
                if (list.Contains(element)) continue;
                else list.Add(element);
                temp = temp | element.SearchEnabledPoint(list);
            }
        }
        return temp;
    }

    public bool GetActiv()
    {
        return activ;
    }

    public virtual void SetActiv(bool activ){
        this.activ = activ;
    }

    public void RemoveActivElementList(ActivElement element)
    {
        listElements.Remove(element);
    }

    public void AddActivElementList(ActivElement element)
    {
        if (!listElements.Contains(element))
            listElements.Add(element);
    }

    void OnDisable()
    {
        if ( exit ) return;
        foreach (ActivElement element in listElements)
        {
            if (element == null) return;
            element.RemoveActivElementList(this);
            element.DeleteWire(this);
        }
        foreach (ActivElement element in listElements)
        {
            element.WireActivAll(element.SearchEnabledPoint());
        }
    }

    private bool exit;
    void OnApplicationQuit(){
        exit=true;
    }
}
