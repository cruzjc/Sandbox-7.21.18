using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioMeasureCS))]
public class MicAudioSimplifier : MonoBehaviour {
    public Hashtable pitchRange;
    public float PickupThreshold;
    private AudioMeasureCS audioMeasureCSInstance;





    void MainInitialization() {
        audioMeasureCSInstance = GetComponent<AudioMeasureCS>();
    }

    #region unity functions
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #endregion unity functions
}
