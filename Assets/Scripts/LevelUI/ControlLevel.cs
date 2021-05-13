using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SettingsData.Instance.configurationData.controlType.Equals("Swipe")){
            gameObject.SetActive(false);
        }
    }

    
}
