using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class IdleState : Istate
{
    private FSM_Character manager;
    private Parameter parameter;
    public IdleState(FSM_Character manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        if (GameObject.FindObjectOfType<Character>().GetComponent<Character>().IsDie == false)
        {
            parameter.animator.Play("Idle_animation");
        }
    }

    public void OnUpdate()
    {
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            manager.TransitionState(StateType.Walk);
        }
        
    }

    public void OnExit()
    {

    }
}

public class WalkState : Istate
{
    private FSM_Character manager;
    private Parameter parameter;
    public WalkState(FSM_Character manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter()
    {
        if (GameObject.FindObjectOfType<Character>().GetComponent<Character>().IsDie == false)
        {
            parameter.animator.Play("Walk_animation");
        }
    }

    public void OnUpdate()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            manager.TransitionState(StateType.Idle);
        }
    }

    public void OnExit()
    {

    }
    public class DieState : Istate
    {
        private FSM_Character manager;
        private Parameter parameter;
        private float timer;
        private AnimatorStateInfo info;
        public DieState(FSM_Character manager)
        {
            this.manager = manager;
            this.parameter = manager.parameter;
        }

        public void OnEnter()
        {
            GameObject.FindObjectOfType<Character>().GetComponent<Character>().m_speed = 100;
            timer = 0;
        }

        public void OnUpdate()
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
            if (timer > 1.5)
            {
                GameObject.FindObjectOfType<Character>().GetComponent<Character>().IsDie = true;
                parameter.animator.Play("Die_animation");
                if (GameObject.FindObjectOfType<Character>().GetComponent<Character>().IsDieAnimationFinish == true)
                {
                    GameObject.FindObjectOfType<ButtonManager>().GetComponent<ButtonManager>().DieMenu.SetActive(true);
                    Time.timeScale = 0;
                }

            }

            if (timer <= 1.5)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    parameter.animator.Play("Walk_animation");
                }
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                {
                    parameter.animator.Play("Idle_animation");
                }
            }
        }

        public void OnExit()
        {
            if (timer > 1.5)
            {
                GameObject.FindObjectOfType<ButtonManager>().GetComponent<ButtonManager>().DieMenu.SetActive(true);
                Time.timeScale = 0;
            }
            GameObject.FindObjectOfType<Character>().GetComponent<Character>().m_speed = 500;
        }
    }
    public class AttackedState : Istate
    {
        private FSM_Character manager;
        private Parameter parameter;
        private AnimatorStateInfo info;
        public AttackedState(FSM_Character manager)
        {
            this.manager = manager;
            this.parameter = manager.parameter;
        }
        public void OnEnter()
        {

        }
        public void OnUpdate()
        {
            parameter.animator.Play("Die_animation");
            if (GameObject.FindObjectOfType<Character>().GetComponent<Character>().IsDieAnimationFinish == true)
            {
                GameObject.FindObjectOfType<ButtonManager>().GetComponent<ButtonManager>().DieMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        public void OnExit()
        {
        }
    }
}
