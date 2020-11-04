using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public static ObjectManager objectManager;
    public static BrushManager brushManager;
    public static WireManager wireManager;
    public static GameObject player;
    void Awake()
    {
        objectManager = Object.FindObjectOfType<ObjectManager>();
        brushManager = Object.FindObjectOfType<BrushManager>();
        wireManager = Object.FindObjectOfType<WireManager>();
    }
}
