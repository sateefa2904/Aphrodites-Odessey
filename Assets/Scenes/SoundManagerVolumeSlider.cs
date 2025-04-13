using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManagerVolumeSlider : MonoBehaviour
{
    public Slider volumeMusic;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float vMusic;
        audioMixer.GetFloat("Volume", out vMusic);
        volumeMusic.value =  vMusic;
    }
}
