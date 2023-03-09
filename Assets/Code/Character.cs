using System.Collections;
using System.Collections.Generic;
//using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Character : BaseUnit
{
    private float XInput;
    [SerializeField]
    private float m_jumpHeight;
    public bool IsAttacked = false;
    public bool IsDie = false;
    public bool IsDieAnimationFinish = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsDieAnimationFinish);
        if (IsDie == false)
        {
            XInput = Input.GetAxis("Horizontal");
            Move(XInput);
            if (IsGrounded(m_xOffset))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector2(rb.velocity.x, m_jumpHeight);
                }
            }
        }
    }
    
    void Die()
    {
        IsDieAnimationFinish = true;
    }
}
