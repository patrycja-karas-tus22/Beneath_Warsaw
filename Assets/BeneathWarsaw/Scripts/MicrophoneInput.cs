using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

public class MicrophoneInput
{
    private string device; //microphone 
    private AudioClip clipRecord = null; //stores audio clip that is filled with audio from microphone
    private int sampleWindow = 128; //audio sampling rate
    private bool isInitialized;
    public static float MicLoudness;

    void Update()
    {
        MicLoudness = LevelMax();
        Debug.Log(MicLoudness);
    }
    
    void OnEnable()
    {
        InitializeMic();
        isInitialized = true;
    }
    void OnDisable()
    {
        StopMic();
    }
    void OnDestroy()
    {
        StopMic();
    }

    private void InitializeMic() //gets data from microphone and passes it into audio clip.
    {
        if (device == null)
        {
            device = Microphone.devices[0];
            clipRecord = Microphone.Start(device, true, 999, 44100); //microphone, whether it's looping, record length in seconds, sample rate of 44.1kHz
        }
    }

    private void StopMic()
    {
        Microphone.End(device);
    }

    private float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[sampleWindow]; //creates an array to store audio samples
        int micPosition = Microphone.GetPosition(null) - (sampleWindow + 1); //gets where new data is being written, subtracts 1 to make sure recent audio is read
        if (micPosition < 0) return 0; //if there's not enough data yet return 0
        clipRecord.GetData(waveData, micPosition); //copies number of samples from the audio clip into the array
        for (int i = 0; i < sampleWindow; i++) //squares each sample, highest value becomes level max.
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax; //returns maximum volume
    }
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (!isInitialized)
            {
                InitializeMic();
                isInitialized = true;
            }
        }
        if (!focus)
        {
            StopMic();
            isInitialized = false;
        }
    }
    
}
