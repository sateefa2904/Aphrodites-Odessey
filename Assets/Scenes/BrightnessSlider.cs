using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public TextMeshProUGUI brightnessPercentage;

    private SpriteRenderer[] spriteRenderers;

    private void Start()
    {
        spriteRenderers = FindObjectsOfType<SpriteRenderer>();
    }

    public void AdjustBrightness(float BrightnessValue)
    {

        //brightnessPercentage.text = (BrightnessValue * 100).ToString("F0") + "%";

        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = new Color(BrightnessValue, BrightnessValue, BrightnessValue, spriteRenderer.color.a);
        }
    }
 
}