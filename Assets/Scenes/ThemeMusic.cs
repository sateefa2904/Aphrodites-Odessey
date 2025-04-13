using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ThemeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    void Start()
    {
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateMusicVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
