using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
        private Vector2 playerDirection;
        //private bool faceright = true;

        private Rigidbody2D rb;

        public Animator anim;

        public float p_speed = 7f;

    private void Start()
    {
        //get animations
        anim = GetComponent<Animator>();

        // get Rigidbody
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;
        //Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * p_speed, playerDirection.y * p_speed);

    }
       
    //private void Flip()
    //{
    //    if (faceright && horizontal < 0f || !faceright && horizontal > 0f)
    //    {
    //        faceright = !faceright;
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1f;
    //        transform.localScale = localScale;
    //    }
    //}

}
