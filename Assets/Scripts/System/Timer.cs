using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    public float time=999;
    public bool activ = true;
    bool animation = false;
    public void Awake(){

    }

    // Update is called once per frame
    void Update()
    {
        
        if (activ)
        {

            var temp = time;
            time -= Time.deltaTime;
            if ((int)temp != (int)time)
            {
                string minutes = Mathf.Floor(time / 60).ToString("00");
                string seconds = (time % 60).ToString("00");

                StaticManager.levelManager.timer.text=string.Format("{0}:{1}", minutes, seconds);
            }

            if (time<=5 && animation==false){
                StaticManager.levelManager.timer.DOColor(Color.red,5);
                StaticManager.levelManager.timer.gameObject.transform.DOShakePosition(5,new Vector3(5,0,0),50,90,false,false);
                animation=true;
                /*
                ObjectManager.uIManager.uiChanging.uiText.transform.eulerAngles= new Vector3(0,0,Mathf.PingPong(Time.time*75,10)-5);
                ObjectManager.uIManager.uiChanging.uiText.color=new Color(1,Mathf.Lerp(0,1,timeLeft/5),Mathf.Lerp(0,1,timeLeft/5),1);*/

            }

            if (time < 0)
            {
                for (int i = ScriptManager.objectManager.AllCharacter.Count-1;i>=0;i--){
                    if (ScriptManager.objectManager.AllCharacter[i].GetComponent<Player>()){
                        ScriptManager.objectManager.AllCharacter[i].GetComponent<Player>().Die();
                    }
                }
                activ = false;
                StaticManager.levelManager.timer.text="00:00";
            }
        }
        
    }
}
