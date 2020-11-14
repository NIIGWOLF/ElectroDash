using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteAlways]
public class GenerateWire : MonoBehaviour
{
    Vector3Int currentPos;
    GameObject wire;
    Tilemap map;
    Line line = new Line();

    public bool isNew = false;

    void Start()
    {
        currentPos = Vector3Int.RoundToInt(transform.position);
        wire = Resources.Load<GameObject>("Wire");
        if (Application.IsPlaying(gameObject))
        {
            map = ScriptManager.objectManager.tilemap;
            if (isNew) CreateWireEdit();
            else CreateWirePlay();
        }
        else
        {
            map = Object.FindObjectOfType<Tilemap>();
            CreateWireEdit();
        }
    }

    void CreateWireEdit()
    {
        GameObject go;
        //right
        go = map.GetInstantiatedObject(currentPos + Vector3Int.right);
        if (go)
            if (go.GetComponent<BasePoint>())
            {
                if (line.GetLine(Vector3Int.right) == (null))
                    line.CreateLine(Vector3Int.right, wire, transform);
                if (go.GetComponent<GenerateWire>().line.GetLine(Vector3Int.left) == (null))
                    go.GetComponent<GenerateWire>().line.CreateLine(Vector3Int.left, wire, go.transform);
            }
        //down
        go = map.GetInstantiatedObject(currentPos + Vector3Int.down);
        if (go)
            if (go.GetComponent<BasePoint>())
            {
                if (line.GetLine(Vector3Int.down) == (null))
                    line.CreateLine(Vector3Int.down, wire, transform);
                if (go.GetComponent<GenerateWire>().line.GetLine(Vector3Int.up) == (null))
                    go.GetComponent<GenerateWire>().line.CreateLine(Vector3Int.up, wire, go.transform);
            }
        //left
        go = map.GetInstantiatedObject(currentPos + Vector3Int.left);
        if (go)
            if (go.GetComponent<BasePoint>())
            {
                if (line.GetLine(Vector3Int.left) == (null))
                    line.CreateLine(Vector3Int.left, wire, transform);
                if (go.GetComponent<GenerateWire>().line.GetLine(Vector3Int.right) == (null))
                    go.GetComponent<GenerateWire>().line.CreateLine(Vector3Int.right, wire, go.transform);
            }
        //up
        go = map.GetInstantiatedObject(currentPos + Vector3Int.up);
        if (go)
            if (go.GetComponent<BasePoint>())
            {
                if (line.GetLine(Vector3Int.up) == (null))
                    line.CreateLine(Vector3Int.up, wire, transform);
                if (go.GetComponent<GenerateWire>().line.GetLine(Vector3Int.down) == (null))
                    go.GetComponent<GenerateWire>().line.CreateLine(Vector3Int.down, wire, go.transform);
            }
    }

    void CreateWirePlay()
    {
        GameObject go;
        //right
        go = map.GetInstantiatedObject(currentPos + Vector3Int.right);
        if (go)
            if (go.GetComponent<BasePoint>())
            {
                if (line.GetLine(Vector3Int.right) == (null))
                    line.CreateLine(Vector3Int.right, wire, transform);
            }
        //down
        go = map.GetInstantiatedObject(currentPos + Vector3Int.down);
        if (go)
            if (go.GetComponent<BasePoint>())
            {
                if (line.GetLine(Vector3Int.down) == (null))
                    line.CreateLine(Vector3Int.down, wire, transform);
            }
        //left
        go = map.GetInstantiatedObject(currentPos + Vector3Int.left);
        if (go)
            if (go.GetComponent<BasePoint>())
            {
                if (line.GetLine(Vector3Int.left) == (null))
                    line.CreateLine(Vector3Int.left, wire, transform);
            }
        //up
        go = map.GetInstantiatedObject(currentPos + Vector3Int.up);
        if (go)
            if (go.GetComponent<BasePoint>())
            {
                if (line.GetLine(Vector3Int.up) == (null))
                    line.CreateLine(Vector3Int.up, wire, transform);
            }
    }

    void OnDestroy()
    {
        if (line.GetLine(Vector3Int.up) != (null))
        {
            map.GetInstantiatedObject(currentPos + Vector3Int.up).GetComponent<GenerateWire>().line.ClearLine(Vector3Int.down);
        }
        if (line.GetLine(Vector3Int.right) != (null))
        {
            map.GetInstantiatedObject(currentPos + Vector3Int.right).GetComponent<GenerateWire>().line.ClearLine(Vector3Int.left);
        }
        if (line.GetLine(Vector3Int.down) != (null))
        {
            map.GetInstantiatedObject(currentPos + Vector3Int.down).GetComponent<GenerateWire>().line.ClearLine(Vector3Int.up);
        }
        if (line.GetLine(Vector3Int.left) != (null))
        {
            map.GetInstantiatedObject(currentPos + Vector3Int.left).GetComponent<GenerateWire>().line.ClearLine(Vector3Int.right);
        }
    }

    public class Line
    {
        GameObject up = null;
        GameObject right = null;
        GameObject down = null;
        GameObject left = null;

        public void CreateLine(Vector3Int direction, GameObject line, Transform parent)
        {
            if (direction.Equals(Vector3Int.up))
            {
                up = Instantiate(line, parent);
                up.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (direction.Equals(Vector3Int.right))
            {
                right = Instantiate(line, parent);
                right.transform.eulerAngles = new Vector3(0, 0, -90);
            }
            if (direction.Equals(Vector3Int.down))
            {
                down = Instantiate(line, parent);
                down.transform.eulerAngles = new Vector3(0, 0, -180);
            }
            if (direction.Equals(Vector3Int.left))
            {
                left = Instantiate(line, parent);
                left.transform.eulerAngles = new Vector3(0, 0, -270);
            }
        }

        public void ClearLine(Vector3Int direction)
        {
            if (direction.Equals(Vector3Int.up))
                DestroyImmediate(up);
            if (direction.Equals(Vector3Int.right))
                DestroyImmediate(right);
            if (direction.Equals(Vector3Int.down))
                DestroyImmediate(down);
            if (direction.Equals(Vector3Int.left))
                DestroyImmediate(left);
        }

        public GameObject GetLine(Vector3Int direction)
        {
            if (direction.Equals(Vector3Int.up))
                return up;
            if (direction.Equals(Vector3Int.right))
                return right;
            if (direction.Equals(Vector3Int.down))
                return down;
            if (direction.Equals(Vector3Int.left))
                return left;
            return null;
        }
    }
}
