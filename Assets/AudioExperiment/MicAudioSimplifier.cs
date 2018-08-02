using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioMeasureCS))]
public class MicAudioSimplifier : MonoBehaviour {
    public Hashtable pitchRange;
    public float PickupThreshold;//threshold for picking up pitch
    private AudioMeasureCS AudioMeasureCSInstance;

    [SerializeField]
    private float averagePitch=0;
    float GetAveragePitch(List<float> audioSampleList) {
        averagePitch = 0;

        for(int i=0;i<audioSampleList.Count;i++){
            averagePitch += audioSampleList[i];
        }

        averagePitch /= audioSampleList.Count;
        
        return averagePitch;
    }


    List<float> AudioSampleHistory = new List<float>();
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
        C,Db,D,Eb,E,F,G,A,B,error
    }
    private float PitchTolerance = 10;
    Note AnalyzeAudioSampleHistory() {
        //todo
        //var AudioSampleDictionary = AudioSampleHistory.ToLookup(x => x);

        RecordAudioSamples();
        float pitch = GetAveragePitch(AudioSampleHistory);

        //maybe not the best way to do this
        float noteCPitch = 261.63f;
        bool noteC = (noteCPitch - PitchTolerance) >= pitch || pitch < (noteCPitch + PitchTolerance);
        float noteDPitch = 293.66f;
        bool noteD = (noteDPitch - PitchTolerance) >= pitch || pitch < (noteDPitch + PitchTolerance);
        float noteEPitch = 329.63f;
        bool noteE = (noteEPitch - PitchTolerance) >= pitch || pitch < (noteEPitch + PitchTolerance);
        float noteFPitch = 349.23f;
        bool noteF = (noteFPitch - PitchTolerance) >= pitch || pitch < (noteFPitch + PitchTolerance);
        float noteGPitch = 392.00f;
        bool noteG = (noteGPitch - PitchTolerance) >= pitch || pitch < (noteGPitch + PitchTolerance);
        float noteAPitch = 440.00f;
        bool noteA = (noteAPitch - PitchTolerance) >= pitch || pitch < (noteAPitch + PitchTolerance);
        float noteBPitch = 493.88f;
        bool noteB = (noteBPitch - PitchTolerance) >= pitch || pitch < (noteBPitch + PitchTolerance);

        if(noteC){
            return Note.C;
        }
        else if (noteD)
        {
            return Note.D;
        }
        else if (noteE)
        {
            return Note.E;
        }
        else if (noteF)
        {
            return Note.F;
        }
        else if (noteG)
        {
            return Note.G;
        }
        else if (noteA)
        {
            return Note.A;
        }
        else if (noteB)
        {
            return Note.B;
        }

        return Note.error;
    }

    void MainInitialization() {
        AudioMeasureCSInstance = GetComponent<AudioMeasureCS>();
    }
    
    #region unity functions
    // Use this for initialization
    void Start () {
        MainInitialization();
	}

    [SerializeField]
    private Note closesNote;
    // Update is called once per frame
	void Update () {
        //RecordAudioSamples();
        closesNote = AnalyzeAudioSampleHistory();
	}

    #endregion unity functions
}

