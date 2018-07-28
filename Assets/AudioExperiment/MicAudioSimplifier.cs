using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioMeasureCS))]
public class MicAudioSimplifier : MonoBehaviour {
    public Hashtable pitchRange;
    public float PickupThreshold;//threshold for picking up pitch
    public float PitchTolerance;
    private AudioMeasureCS AudioMeasureCSInstance;


    float GetAveragePitch() {
        float Average = 0;

        




        return Average;


    }


    List<float> AudioSampleHistory;
    int AudioSampleHistoryLimit;//used to keep list from overgrowing
    float durationToAnalyze = 0.5f;//how far back in time to analyze
    float totalDeltaTime=0;
    void RecordAudioSamples() {
        float currentPitch = AudioMeasureCSInstance.PitchValue;

        AudioSampleHistory.Add(currentPitch);
        totalDeltaTime += Time.deltaTime;

        if (AudioSampleHistory.Count > AudioSampleHistoryLimit ||
            totalDeltaTime > durationToAnalyze) {
            AudioSampleHistory.RemoveAt(0);
            totalDeltaTime -= Time.deltaTime;
        }
    }

    //https://stackoverflow.com/questions/11581101/c-sharp-convert-liststring-to-dictionarystring-string
    enum Note {
        C,Db,D,Eb,E,F,G,A,B
    }
    Note AnalyzeAudioSampleHistory() {
        //todo
        var AudioSampleDictionary = AudioSampleHistory.ToLookup(x => x);
        return Note.C;
    }

    void MainInitialization() {
        AudioMeasureCSInstance = GetComponent<AudioMeasureCS>();
    }

    #region unity functions
    // Use this for initialization
    void Start () {
        MainInitialization();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion unity functions
}

