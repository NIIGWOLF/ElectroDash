using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          gameObject.GetComponent<Slider>().value = MainMenuManager.audioData.audio.musicVolume;
        
    }

    // Update is called once per frame
   public void soundsChange(){
        foreach(var sound in MainMenuManager.uiMainMenuManager.music.GetComponentsInChildren<AudioSource>()){
            sound.volume = gameObject.GetComponent<Slider>().value;
        }
        MainMenuManager.audioData.audio.musicVolume = gameObject.GetComponent<Slider>().value;
        MainMenuManager.audioData.SaveData();
    }
}
