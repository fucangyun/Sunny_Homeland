using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class IdleState_Jacbo : Istate
{
    private FSM_Jacbo manager;
    private Parameter_Jacbo parameter;
    public IdleState_Jacbo(FSM_Jacbo manager)
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
            manager.TransitionState(StateType_Jacbo.Walk_Jacbo);
        }
        
    }

    public void OnExit()
    {

    }
}

public class WalkState_Jacbo : Istate
{
    private FSM_Jacbo manager;
    private Parameter_Jacbo parameter;
    public WalkState_Jacbo(FSM_Jacbo manager)
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
            manager.TransitionState(StateType_Jacbo.Idle_Jacbo);
        }
    }

    public void OnExit()
    {

    }
    public class DieState_Jacbo : Istate
    {
        private FSM_Jacbo manager;
        private Parameter_Jacbo parameter;
        private float timer;
        private AnimatorStateInfo info;
        public DieState_Jacbo(FSM_Jacbo manager)
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
            GameObject.FindObjectOfType<Character>().GetComponent<Character>().m_speed = 300;
        }
    }
    public class AttackedState_Jacbo : Istate
    {
        private FSM_Jacbo manager;
        private Parameter_Jacbo parameter;
        private AnimatorStateInfo info;
        public AttackedState_Jacbo(FSM_Jacbo manager)
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
