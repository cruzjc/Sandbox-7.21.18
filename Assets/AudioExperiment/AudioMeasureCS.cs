using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script basically came from here. huge help.
//https://answers.unity.com/questions/157940/getoutputdata-and-getspectrumdata-they-represent-t.html

public class AudioMeasureCS : MonoBehaviour {

    public float RmsValue;//sound level in RMS
    public float DbValue;//sound level in dB
    public float PitchValue;//sound pitch

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.2f;//minimum amplitude to extract pitch

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;


	// Use this for initialization
	void Start () {
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;
	}
	
	// Update is called once per frame
	void Update () {
        AnalyzeSound();
	}

    void AnalyzeSound(){
        GetComponent<AudioSource>().GetOutputData(_samples, 0);//fill array with sample
        int i;
        float sum = 0;

        //sum squared samples
        for(i=0;i<QSamples;i++){
            sum += _samples[i] * _samples[i];
        }

        //rms=square root of average
        RmsValue = Mathf.Sqrt(sum / QSamples);

        //calculate dB
        DbValue = 20 * Mathf.Log10(RmsValue / RefValue);
        //sets allowed minimum value
        if(DbValue<-160){
            DbValue = -160;
        }

        //get sound spectrum
        GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for(i=0;i<QSamples;i++){
            bool condition1 = _spectrum[i] > maxV;
            bool condition2 = _spectrum[i] > Threshold;
                if(condition1||condition2){
                maxV = _spectrum[i];
                maxN = i;
            }
        }

        //pass index to a float variable
        float freqN = maxN;

        //interpolate index using neighbours
        bool condition3 = maxN > 0;
        bool condition4 = maxN < (QSamples - 1);
        if(condition3&&condition4){
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
            //Debug.Log("frezN: "+freqN);
        }

        //convert index to frequency
        PitchValue = freqN * (_fSample / 2) / QSamples;
        //Debug.Log(PitchValue.ToString("F0") + " Hz");
    }
}
