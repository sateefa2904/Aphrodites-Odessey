using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ChangeMuteButton : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;
    
    public AudioSource audioSource;
    //public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        soundOnImage = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        float v;
        float vMusic;
        //volumMusic.value = vMusic;
        //volumSFX.value = v;
    }
    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
        }
        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
        }
    }
}
