using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class IdleState_Enemy : Istate
{
    private FSM_Enemy manager;
    private Parameter_Enemy parameter;
    private float timer;
    public IdleState_Enemy(FSM_Enemy manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {

        parameter.animator.Play("Idle_animation");
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= parameter.idleTime)
        {
            manager.TransitionState(StateType_Enemy.Patrol);
        }
    }

    public void OnExit()
    {
        timer = 0;
    }
}

public class PatrolState_Enemy : Istate
{
    private FSM_Enemy manager;
    private Parameter_Enemy parameter;
    private int patrolPosition;
    public PatrolState_Enemy(FSM_Enemy manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        parameter.animator.Play("Walk_animation");
    }

    public void OnUpdate()
    {
        Debug.Log(parameter.target);
        if (parameter.target != null &&
           parameter.target.position.x >= parameter.chasePoints[0].position.x &&
           parameter.target.position.x <= parameter.chasePoints[1].position.x)
        {
            manager.TransitionState(StateType_Enemy.Chase);
        }
        manager.FlipTo(parameter.patrolPoints[patrolPosition]);

        manager.transform.position = Vector2.MoveTowards(manager.transform.position,
            parameter.patrolPoints[patrolPosition].position, parameter.moveSpeed * Time.deltaTime);

        if (Vector2.Distance(manager.transform.position, parameter.patrolPoints[patrolPosition].position) < .1f)
        {
            manager.TransitionState(StateType_Enemy.Idle);
        }
    }

    public void OnExit()
    {
        patrolPosition++;

        if (patrolPosition >= parameter.patrolPoints.Length)
        {
            patrolPosition = 0;
        }
    }
}

public class ChaseState_Enemy : Istate
{
    private FSM_Enemy manager;
    private Parameter_Enemy parameter;

    public ChaseState_Enemy(FSM_Enemy manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        Debug.Log("Chasing");
        parameter.animator.Play("Walk_animation");
    }

    public void OnUpdate()
    {
        manager.FlipTo(parameter.target);
        if (parameter.target)
            manager.transform.position = Vector2.MoveTowards(manager.transform.position,
                parameter.target.position, parameter.chaseSpeed * Time.deltaTime);

        if (parameter.target == null ||
            manager.transform.position.x < parameter.chasePoints[0].position.x ||
            manager.transform.position.x > parameter.chasePoints[1].position.x)
        {
            manager.TransitionState(StateType_Enemy.Idle);
        }
        if (Physics2D.OverlapCircle(parameter.attackPoint.position, parameter.attackArea, parameter.targetLayer))
        {
            manager.TransitionState(StateType_Enemy.Attack);
        }
    }

    public void OnExit()
    {

    }
}


public class AttackState_Enemy : Istate
{
    private FSM_Enemy manager;
    private Parameter_Enemy parameter;
    //private AnimatorStateInfo info;

    public AttackState_Enemy(FSM_Enemy manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        parameter.animator.Play("Attack_animation");
    }

    public void OnUpdate()
    {
        /*info = parameter.animator.GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime >= .95f)
        {*/
        parameter.target.gameObject.GetComponent<Character>().IsDie = true;
        parameter.target.gameObject.GetComponent<Character>().IsAttacked = true;
            //manager.TransitionState(StateType_Enemy.Chase);
        //}
    }

    public void OnExit()
    {

    }
}


