using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
   public TextMeshProUGUI brightnessPercentage;

   private SpriteRenderer[] spriteRenderers;

   public AudioMixer audioMixer;

   private void Start()
   {
      spriteRenderers = FindObjectsOfType<SpriteRenderer>();
   }
   
   public void SetVolume(float Volume)
   {
        audioMixer.SetFloat("Volume", Volume);
   }

   public void AdjustBrightness(float BrightnessValue)
   {
         brightnessPercentage.text = (BrightnessValue * 100).ToString("F0") + "%";

         foreach(SpriteRenderer spriteRenderer in spriteRenderers)
         {
            spriteRenderer.color = new Color(BrightnessValue, BrightnessValue, BrightnessValue, spriteRenderer.color.a);
         } 
   }
   
}
