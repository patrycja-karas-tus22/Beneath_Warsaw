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
        float loudness = MicrophoneInput.MicLoudness;
        float normalized = Mathf.Clamp(loudness * 200f, 0f, 1f);

        volumeBar.fillAmount = normalized;

        if (loudness < quiet)
        {
            volumeBar.color = Color.green;  
        } else if (loudness < medium)
        {
            volumeBar.color = Color.orange;
        } else
        {
            volumeBar.color = Color.red;
        }
    }
}
