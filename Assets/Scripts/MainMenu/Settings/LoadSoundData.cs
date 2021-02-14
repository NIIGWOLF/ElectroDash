using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSoundData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var audio in gameObject.GetComponentsInChildren<AudioSource>()){
            audio.volume = AudioData.Instance.audio.soundsVolume; }
        
    }

    
}
