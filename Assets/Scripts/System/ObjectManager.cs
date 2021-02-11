using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectManager : MonoBehaviour
{
    public Tilemap tilemap;    
    public GameObject BlackBarier;
    public List<GameObject> AllCharacter = new List<GameObject>();
    public bool activStartDaethPS = true;

    void OnApplicationQuit()
    {
        activStartDaethPS = false;
    }
}
