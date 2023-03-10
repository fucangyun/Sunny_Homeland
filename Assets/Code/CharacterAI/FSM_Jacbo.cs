using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static WalkState_Jacbo;

public enum StateType_Jacbo
{
    Idle_Jacbo, Walk_Jacbo, Die_Jacbo, Attacked_Jacbo
}
[Serializable]
public class Parameter_Jacbo
{
    public Animator animator;
}
public class FSM_Jacbo : MonoBehaviour
{
    public Parameter_Jacbo parameter;
    private Istate currentState;
    private Dictionary<StateType_Jacbo, Istate> states = new Dictionary<StateType_Jacbo, Istate>();
    [SerializeField]
    private GameObject roomBegin;
    void Start()
    {
        states.Add(StateType_Jacbo.Idle_Jacbo, new IdleState_Jacbo(this));
        states.Add(StateType_Jacbo.Walk_Jacbo, new WalkState_Jacbo(this));
        states.Add(StateType_Jacbo.Die_Jacbo, new DieState_Jacbo(this));
        states.Add(StateType_Jacbo.Attacked_Jacbo, new AttackedState_Jacbo(this));

        TransitionState(StateType_Jacbo.Idle_Jacbo);

        parameter.animator = GetComponent<Animator>();
        if(roomBegin != null)
        {
            transform.SetParent(roomBegin.transform);
            gameObject.SetActive(false);
        }
        
    }

    void Update()
    {
        currentState.OnUpdate();
        if (GetComponent<Character>().IsAttacked == true)
        {
            TransitionState(StateType_Jacbo.Attacked_Jacbo);
        }
    }

    public void TransitionState(StateType_Jacbo type)
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
        
        if (collision.gameObject.GetComponent<WhiteLightComponent>() != null)
        {
            TransitionState(StateType_Jacbo.Die_Jacbo);
        }
        if (collision.gameObject.GetComponent<DarkLightComponent>() != null)
        {
            TransitionState(StateType_Jacbo.Idle_Jacbo);
        }
    }
}