using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.unity3d.com/ScriptReference/WaitForSeconds.html

//auto adds component
//[RequireComponent(typeof())]

public class HawaiianBobtailSquid : MonoBehaviour {
    [SerializeField]
    [Tooltip("Component References")]
    private ComponentReferences CR;

    [SerializeField]
    [Tooltip("Primary Stats")]
    protected PrimaryStats PS;

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
        PS.Patience += RateUtility(PatienceRecoveryUnit, PatienceRecoveryRate);
    }
    #endregion

    #region statUpdate:Hunger
    protected float HungerRecoveryUnit;
    protected float HungerRecoveryRate;
    private void PassiveHungerStatRecovery() {
        PS.Hunger += RateUtility(HungerRecoveryUnit, HungerRecoveryRate);
    }
    #endregion

    #endregion primary stats update functions

    #region primary state machine
    private enum State {
        idle, crying, hungry, irked,
        angry, happy, sleeping, retrievingItem,
        givingItemToPlayer
    }
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
            case State.retrievingItem:
                RetrievingItem();
                break;

            default:
                Debug.LogError("Primary state machine defaulting", gameObject);
                break;
        }
    }

    #region State Behaviors
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

    GameObject ItemOfInterest;
    GameObject ItemCarrying;//item that it is carrying
    void RetrievingItem() {

        //if has an item of interest and is retriving it...
        bool condition1 = ItemOfInterest;
        bool condition2 = currentState == State.retrievingItem;
        if (condition1&&condition2) {
            //move towards item
            //todo create function to move to new location
            //might just use unity's navmesh
            //and anchor a character collider to the 
            //seafloor. would adjust 'height' if colliding with object
            //or just stretch collider height wise
        }
        
    }

    void GivingItemToPlayer() {

        bool condition1 = ItemCarrying;
        bool condition2 = currentState == State.givingItemToPlayer;
        if (condition1 && condition2) {
            //move towards player
            //todo create function to move and give item to player
            //same mechanic as retrieving item
        }
    }
    #endregion State Behaviors

    #endregion primary state machine



    #region unity functions
    // Use this for initialization
    void Start() {
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

    }
    #endregion main initialization function

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

#region Component References
//https://answers.unity.com/questions/1261103/how-to-group-public-variables-in-the-editor.html
//stuff to drag into inspector
[System.Serializable]
public struct ComponentReferences {


    public GameObject player;

    #region colliders
    public Collider InteractCollider;
    public Collider BodyPhysicsCollider;
    #endregion colliders
    
    #region animation
    public Animator AnimatorComponent;
    #endregion animation
    
    #region sound
    public AudioSource AudioSourceComponent;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    #endregion sound

}
#endregion Component References

#region Primary Stats
[System.Serializable]
public struct PrimaryStats {
    #region stat:OverallMood
    [SerializeField]
    //private int _overallMood;//overall mood
    private int OverallMood {
        get { return 0; }
        set { Debug.Log("Can't set OverallMood variable, dependent on other stats"); }
    }
    #endregion stat:OverallMood

    #region stat:Patience
    public int PatienceMax;
    public float _patience;//tolerance for players bs
    public float Patience {
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
    public int HungerMax;
    public float _hunger;//how hungry
    public float Hunger {
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
    public int UpsetMax;
    public float _upset;//how upset
    public float Upset {
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
    public int ExcitementMax;
    public float _excitement;//used to trigger an excited state
    public float Excitement {
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
}
#endregion Primary Stats