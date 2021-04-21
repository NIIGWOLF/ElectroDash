using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    Player player;

    void Start(){
        Invoke("Init",1);
    }
    void Init(){
        player = ScriptManager.player.GetComponent<Player>();
    }
    public void downKey(int dir){
        player.Swipe(dir);
    }
}
