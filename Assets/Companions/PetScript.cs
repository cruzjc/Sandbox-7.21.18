using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour {
    #region other variables
    [SerializeField]
    private new string name;
    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }

    [SerializeField]
    private float energy;
    public float Energy {
        get {
            return energy;
        }
        set {
            energy = value;
        }
    }

    [SerializeField]
    private float attention;
    public float Attention {
        get {
            return energy;
        }
        set {
            attention = value;
        }
    }

    [SerializeField]
    private float poopTime;
    public float PoopTime {
        get {
            return energy;
        }
        set {
            poopTime = value;
        }
    }

    #endregion

    #region variable mutator functions
    void setName(string newName) {
        Name = newName;
    }

    void giveEnergy(float amount) {
        Energy = amount;
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

    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        primaryStateMachine();
    }

    #endregion
}
