using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public enum StateType_Enemy
{
    Idle, Patrol, Chase, Attack
}
[Serializable]
public class Parameter_Enemy
{
    public int health;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;
    public float attackArea;
    public Animator animator;
}
public class FSM_Enemy : MonoBehaviour
{
    public Parameter_Enemy parameter;
    private Istate currentState;
    private Dictionary<StateType_Enemy, Istate> states = new Dictionary<StateType_Enemy, Istate>();
    void Start()
    {
        states.Add(StateType_Enemy.Idle, new IdleState_Enemy(this));
        states.Add(StateType_Enemy.Patrol, new PatrolState_Enemy(this));
        states.Add(StateType_Enemy.Chase, new ChaseState_Enemy(this));
        states.Add(StateType_Enemy.Attack, new AttackState_Enemy(this));

        TransitionState(StateType_Enemy.Idle);

        parameter.animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType_Enemy type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-8, 8, 8);
            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(8, 8, 8);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>())
        {
            parameter.target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>())
        {
            parameter.target = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
    }
} 
