using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    UI uiaccess;
    [SerializeField] GameObject ui;

    public delegate void PowerUpDelegate();
    public PowerUpDelegate PUDelegate;  

    private Vector2 playerDirection;
    private Rigidbody2D rb;
    private Animator anim;
    private bool faceright = true;

    public float p_speed;
    public float P_hp;
    
    void Awake ()
    {
        uiaccess = ui.GetComponent<UI>();
    }

    private void Start()
    {
        //get animations
        anim = GetComponent<Animator>();

        // get Rigidbody
        rb = GetComponent<Rigidbody2D>();

        
    }

    void Update()
    {
        GameManager.instance.LevelTimer();
        GameManager.instance.CheckStage(gameObject);

        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;

        anim.SetFloat("Speed", rb.velocity.magnitude);
        anim.SetFloat("Hp", P_hp);

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * p_speed, playerDirection.y * p_speed);

    }

 //Player Flip R to L-------------------------------------------------------------------------------------------------

    private void Flip()
    {
        if (faceright && Input.GetAxisRaw("Horizontal") < 0f || !faceright && Input.GetAxisRaw("Horizontal") > 0f)
        {
            faceright = !faceright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    //GameOver-------------------------------------------------

    public void GameOver()
    {
        P_hp = 0;
        anim.Play("GameOverHead");
        SceneManager.LoadScene("EndScore");
        Destroy(gameObject, 0.8f);
    }
    //The Death Animation never plays as the Scene change is too fast, tried to fix it but couldn't find a reliable way on time, sorry.--------------

 //Power Up Activation-------------------------------------

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PUP")
        {
            if (PUDelegate != null)
            {
                PUDelegate();

                Destroy(coll.gameObject);
            }
        }
    }   

}
