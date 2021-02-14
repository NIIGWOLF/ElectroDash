using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMusicDataLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         foreach (var audio in gameObject.GetComponentsInChildren<AudioSource>()){
            audio.volume = MainMenuManager.audioData.audio.musicVolume; }
    }

   
}
