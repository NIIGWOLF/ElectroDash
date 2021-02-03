using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public static ObjectManager objectManager;
    public static WireManager wireManager;
    public static GameObject player;
    void Awake()
    {
        objectManager = Object.FindObjectOfType<ObjectManager>();
        wireManager = Object.FindObjectOfType<WireManager>();
    }
}
