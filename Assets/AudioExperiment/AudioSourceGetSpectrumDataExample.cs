using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.unity3d.com/ScriptReference/AudioSource.GetSpectrumData.html
//https://support.unity3d.com/hc/en-us/articles/206485253-How-do-I-get-Unity-to-playback-a-Microphone-input-in-real-time-
//https://docs.unity3d.com/ScriptReference/Microphone.Start.html


[RequireComponent(typeof(AudioSource))]
public class AudioSourceGetSpectrumDataExample : MonoBehaviour
{
    private void Start()
    {
        //DisplayMicrophoneDevices();

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(Microphone.devices.GetValue(0).ToString(), true, 1, 48000);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null)>0)) { }
        audioSource.Play();

    }

    void Update()
    {
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
    }


    void DisplayMicrophoneDevices()
    {
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);

            int minFrequency = 0;
            int maxFrequency = 0;
            Microphone.GetDeviceCaps(device, out minFrequency, out maxFrequency);
            Debug.Log("minFreq: " + minFrequency);
            Debug.Log("maxFreq: " + maxFrequency);

        }

    }
}
