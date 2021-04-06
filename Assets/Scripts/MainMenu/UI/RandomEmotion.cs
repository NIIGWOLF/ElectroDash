using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
public class RandomEmotion : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> list = new List<Sprite>();
    System.Timers.Timer timer;
    void Start()
    {
       /* timer = new System.Timers.Timer();
        timer.Interval = 1200;
        print("timer 1200");
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
        */
        InvokeRepeating("InvokeTimer", 0, 4);
        
    }
    void InvokeTimer(){
        Invoke( "onTimes",Random.Range(0, 3.9f));
    }
     void onTimes(){
        int index = Random.Range(0, list.Count);
         print("timer random");
        gameObject.GetComponent<SpriteRenderer>().sprite = list[index];
       
    }
    void onTime(object source, System.Timers.ElapsedEventArgs e){
        int index = Random.Range(0, list.Count);
         print("timer random");
        gameObject.GetComponent<SpriteRenderer>().sprite = list[index];
        timer.Interval = Random.Range(1000, 3000);
        timer.Enabled = true;
    }
     private void OnTimedEvent(System.Object source, System.Timers.ElapsedEventArgs e)
    {
         int index = Random.Range(0, list.Count);
         print("timer random");
        gameObject.GetComponent<SpriteRenderer>().sprite = list[index];
        timer.Interval = Random.Range(1000, 3000);
        timer.Enabled = true;
    }
   
}
