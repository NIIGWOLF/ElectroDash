using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public static ObjectManager objectManager;
    void Awake()
    {
        objectManager = Object.FindObjectOfType<ObjectManager>();
    }
}
