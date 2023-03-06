using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static WalkState;

public enum StateType
{
    Idle, Walk, Die
}
[Serializable]
public class Parameter
{
    public Animator animator;
}
public class FSM_Character : MonoBehaviour
{
    public Parameter parameter;
    private Istate currentState;
    private Dictionary<StateType, Istate> states = new Dictionary<StateType, Istate>();
    void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Walk, new WalkState(this));
        states.Add(StateType.Die, new DieState(this));

        TransitionState(StateType.Idle);

        parameter.animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<DarkLightComponent>() != null)
        {
            Debug.Log("Enter");
            TransitionState(StateType.Die);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DarkLightComponent>() != null)
        {
            TransitionState(StateType.Idle);
        }
    }
}