using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [SerializeField]
    public float m_speed;
    private float m_animSpeed;
    private Vector2 m_raystart;
    [SerializeField]
    protected float m_rayLength;
    [SerializeField]
    protected float m_xOffset;
    //protected SpriteRenderer sr;
    protected Animator anim;
    protected Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void Move(float direction)
    {
        if (direction > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }

        rb.velocity = new Vector2(direction * m_speed, rb.velocity.y);
    }
    protected bool IsGrounded(float xOffset)
    {
        m_raystart = new Vector2(transform.position.x + xOffset, transform.position.y);
        int shootableMask = LayerMask.GetMask("Ground");
        RaycastHit2D hitinfo;
        hitinfo = Physics2D.Raycast(m_raystart, Vector2.down, m_rayLength,shootableMask);
        Debug.DrawRay(transform.position, Vector2.down, Color.red, m_rayLength);
        if (hitinfo.collider != null)
        {
            return true;
        }
        return false;
    }
}
