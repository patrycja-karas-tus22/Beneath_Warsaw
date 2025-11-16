using UnityEngine;
using UnityEngine.UI;

public class MicVolumeUI : MonoBehaviour
{
    public Image volumeBar;

    public float quiet = 0.001f;
    public float medium = 0.005f;
    public float loud = 0.02f;


    // Update is called once per frame
    void Update()
    {
        float loudness = MicrophoneInput.TotalLoudness;
        float normalized = Mathf.Clamp(loudness * 200f, 0f, 1f);

        // Current fill amount
        float currentFill = volumeBar.fillAmount;

        // Smoothly interpolate toward new loudness value
        volumeBar.fillAmount = Mathf.Lerp(currentFill, normalized, Time.deltaTime * 5f);

        if (volumeBar.fillAmount < 0.2f)
        {
            volumeBar.color = Color.green;
        }
        else if (volumeBar.fillAmount < 0.5f)
        {
            volumeBar.color = new Color(1f, 0.64f, 0f); // orange
        }
        else
        {
            volumeBar.color = Color.red;
        }
    }
}
