using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStateMenu : MonoBehaviour
{
    
    public void SetState(int state)
    {
        MainMenuManager.stateMenu = state;
    }
}
