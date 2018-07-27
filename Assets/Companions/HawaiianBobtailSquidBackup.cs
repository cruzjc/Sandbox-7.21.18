using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.unity3d.com/ScriptReference/WaitForSeconds.html

//auto adds component
//[RequireComponent(typeof())]

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class HawaiianBobtailSquidBackup : MonoBehaviour {
    #region primary stats
    #region stat:OverallMood
    [SerializeField]
    //private int _overallMood;//overall mood
    private int OverallMood {
        get { return 0; }
        set { Debug.Log("Can't set OverallMood variable, dependent on other stats"); }
    }
    #endregion stat:OverallMood

    #region stat:Patience
    [SerializeField]
    protected int PatienceMax;
    [SerializeField]
    protected float _patience;//tolerance for players bs
    protected float Patience {
        get { return _patience; }
        set {
            if (_patience + value > PatienceMax) {
                _patience = PatienceMax;
            } else {
                _patience = value;
            }
        }
    }
    #endregion stat:Patience

    #region stat:Hunger
    [SerializeField]
    protected int HungerMax;
    [SerializeField]
    protected float _hunger;//how hungry
    protected float Hunger {
        get { return _hunger; }
        set {
            if (_hunger + value > HungerMax) {
                _hunger = HungerMax;
            } else {
                _hunger = value;
            }
        }
    }
    #endregion stat:Hunger

    #region stat:Upset
    [SerializeField]
    protected int UpsetMax;
    [SerializeField]
    protected float _upset;//how upset
    protected float Upset {
        get { return _upset; }
        set {
            if (_upset + value > UpsetMax) {
                _upset = UpsetMax;
            } else {
                _upset = value;
            }
        }
    }
    #endregion stat:Upset

    #region stat:Excitement
    [SerializeField]
    protected int ExcitementMax;
    [SerializeField]
    protected float _excitement;//used to trigger an excited state
    protected float Excitement {
        get { return _excitement; }
        set {
            if (_excitement + value > ExcitementMax) {
                _excitement = ExcitementMax;
            } else {
                _excitement = value;
            }
        }
    }
    #endregion stat:Excitement
    #endregion primary stats

    #region stat initialization
    void PrimaryStatInitialization() {
        PatienceMax = 100;
        HungerMax = 100;
        UpsetMax = 100;
        ExcitementMax = 100;
    }
    #endregion stat initialization

    #region primary stats update functions
    //to be called in update,updates stats (to recover,etc)
    void PrimaryStatUpdate() {
        PassivePatienceStatRecovery();
        PassiveHungerStatRecovery();
    }

    #region statUpdate:Patience
    protected float PatienceRecoveryUnit;
    protected float PatienceRecoveryRate;
    private void PassivePatienceStatRecovery() {
        Patience += RateUtility(PatienceRecoveryUnit, PatienceRecoveryRate);
    }
    #endregion

    #region statUpdate:Hunger
    protected float HungerRecoveryUnit;
    protected float HungerRecoveryRate;
    private void PassiveHungerStatRecovery() {
        Hunger += RateUtility(HungerRecoveryUnit, HungerRecoveryRate);
    }
    #endregion

    #endregion primary stats update functions

    #region primary state machine
    private enum State { idle, crying, hungry, irked, angry, happy, sleeping }
    [SerializeField]
    private State currentState;
    void PrimaryStateMachine() {
        switch (currentState) {
            case State.idle:
                idlingState();
                break;
            case State.crying:
                cryingState();
                break;
            case State.hungry:
                hungryState();
                break;
            case State.irked:
                irkedState();
                break;
            case State.angry:
                angryState();
                break;
            case State.happy:
                happyState();
                break;
            case State.sleeping:
                sleepingState();
                break;

            default:
                Debug.LogError("Primary state machine defaulting", gameObject);
                break;
        }
    }


    #endregion

    #region state behaviors
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
        PrimaryStatInitialization();
        MainInitialization();
    }

    // Update is called once per frame
    void Update() {
        PrimaryStatUpdate();
        PrimaryStateMachine();
    }

    private void FixedUpdate() {

    }



    #endregion unity functions

    #region main initialization function
    void MainInitialization() {
        AddInteractCollider();

        SetupAnimationComponent();
        SetupAudioSourceComponent();
    }
    #endregion main initialization function

    #region animation
    void SetupAnimationComponent() {

    }
    #endregion animation

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

    #endregion sound

    #region collision
    GameObject InteractColliderGameObject;
    string InteractColliderGameObjectName;
    Collider InteractCollider;
    Collider BodyCollider;
    void SetupInteractCollider() {

    }

    void AddInteractCollider() {
        InteractColliderGameObjectName = "InteractColliderGameObject";
        InteractColliderGameObject = transform.Find(InteractColliderGameObjectName).gameObject;
        InteractCollider = InteractColliderGameObject.GetComponent<Collider>();
        bool condition1 = InteractCollider != null;
        bool condition2 = InteractCollider != null;
        if (condition1 && condition2) {
            //interact collider found and assigned
            return;
        }

        if (!condition1) {
            InteractColliderGameObject = new GameObject(InteractColliderGameObjectName);
        }

        if (!condition2) {
            InteractCollider = InteractColliderGameObject.AddComponent<CapsuleCollider>();
        }
    }
    #endregion

    #region utility functions

    //currentTim:=use outer float variable
    //trigger:use outer bool variable
    //todo
    public void Timer(float startingTime, out float currentTime, out bool trigger) {
        currentTime = 0;
        trigger = false;

        if (trigger == false) {
            currentTime -= Time.deltaTime;
        }


        if (currentTime < 0) {
            trigger = true;
            currentTime = startingTime;
        }
    }

    //helps process a rate (unit per time),uses Time.deltaTime
    public float RateUtility(float unit, float time) {
        float result = (Time.deltaTime * unit) / time;
        return result;
    }
    # endregion utility functions
}
