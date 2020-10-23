using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Character : MonoBehaviour
{
    protected bool isMove = false;
    protected Vector3Int backPos;
    protected Vector3Int nextPos = new Vector3Int(0, 0, 1);
    protected Vector3Int currentPos;
    protected float speed = 5f;
    protected Tilemap tileMap;

    protected virtual void Start()
    {
        backPos = Vector3Int.CeilToInt(transform.position);
        tileMap = ScriptManager.objectManager.tilemap;
        currentPos = Vector3Int.CeilToInt(transform.position);
    }

    public virtual void returnBack(){
        Vector3Int temp = backPos;
        backPos = nextPos;
        nextPos = temp;
    }

    public virtual void Die(){
        Destroy(gameObject);
    }
}
