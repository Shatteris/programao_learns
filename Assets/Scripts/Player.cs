using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
        private float horizontal;
        private bool faceright = true;

        private Rigidbody2D rb;
        private bool groundCheck;
        private RaycastHit2D hit;
        private LayerMask Floor;

        public Animation anim;
        public float p_life = 3f;
        public float p_speed = 7f;
        public float p_jump = 12f;

    void Start()
    {
        ///get animations
        anim = GetComponent<Animation>();

        /// get Rigidbody
        rb = GetComponent<Rigidbody2D>();

        /// get RayCast
        hit = GetComponent<RaycastHit2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, p_jump);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * p_speed, rb.velocity.y);




    }

    private bool IsGrounded()
    {
        ///    var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        ///    return groundCheck.collider != null && groundCheck.collider.CompareTag("Floor");

        hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);
        if (hit.collider != null)
        {
            groundCheck = false;
        }
        else
        {
            groundCheck = true;
        }

        return groundCheck;
    }
        

    private void Flip()
    {
        if (faceright && horizontal < 0f || !faceright && horizontal > 0f)
        {
            faceright = !faceright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
