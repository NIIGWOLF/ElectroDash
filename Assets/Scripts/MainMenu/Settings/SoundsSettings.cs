using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundsSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Slider>().value = AudioData.Instance.audio.soundsVolume;
    }

    public void soundsChange(){
        foreach(var sound in MainMenuManager.uiMainMenuManager.audioSource.GetComponentsInChildren<AudioSource>()){
            sound.volume = gameObject.GetComponent<Slider>().value;
        }
        AudioData.Instance.audio.soundsVolume = gameObject.GetComponent<Slider>().value;
        AudioData.Instance.SaveData();
    }
}
