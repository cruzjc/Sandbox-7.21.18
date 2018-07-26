using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//auto adds component
//[RequireComponent(typeof())]

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(AudioSource))]
public class HawaiianBobtailSquid : MonoBehaviour {
    #region other variables
    [SerializeField]
    private string _name;
    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }

    [SerializeField]
    private float _attention;
    public float Attention {
        get {
            return _attention;
        }
        set {
            _attention = value;
        }
    }

    #endregion

    #region variable mutator functions
    void setName(string newName) {
        Name = newName;
    }

    void giveAttention(float amount) {
        Attention = amount;
    }

    #endregion

    #region primary state machine
    public enum state { idle, crying, hungry, irked, angry, happy, sleeping }
    public state currentState;
    void primaryStateMachine() {
        switch (currentState) {
            case state.idle:
                idlingState();
                break;
            case state.crying:
                cryingState();
                break;
            case state.hungry:
                hungryState();
                break;
            case state.irked:
                irkedState();
                break;
            case state.angry:
                angryState();
                break;
            case state.happy:
                happyState();
                break;
            case state.sleeping:
                sleepingState();
                break;

            default:
                Debug.LogError("Primary state machine defaulting", gameObject);
                break;
        }
    }


    #endregion

    #region behaviors
    void idlingState() {
        //todo
    }

    void cryingState() {
        //todo
    }

    void hungryState() {
        //todo
    }

    void irkedState() {
        //todo
    }

    void angryState() {
        //todo
    }

    void happyState() {
        //todo
    }

    void sleepingState() {
        //todo
    }
    #endregion

    #region unity functions
    // Use this for initialization
    void Start() {
        MainInitialization();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        primaryStateMachine();
    }

    #endregion

    #region main initialization function
    void MainInitialization() {
        SetupAnimationComponent();
        SetupAudioSourceComponent();
    }
    #endregion

    #region animation
    void SetupAnimationComponent() {

    }
    #endregion

    #region sound
    AudioSource audioSource;
    AudioClip clip1;
    AudioClip clip2;
    AudioClip clip3;
    AudioClip clip4;
    AudioClip clip5;
    AudioClip clip6;

    void SetupAudioSourceComponent() {
        audioSource = GetComponent<AudioSource>();
    }
    
    #endregion
}
