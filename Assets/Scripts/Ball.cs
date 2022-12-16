using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource bonk;
    public float bforce;
    public float timer = 0f;
    public float EndTime = 10.0f;

    private Rigidbody2D rball;

    Vector3 lastVelocity;

    Player MyPlayer;

    public GameObject Green;
    public GameObject Red;
    public GameObject Skull;

    // the range of X
    public float xMin;
    public float xMax;

    // the range of y
    public float yMin;
    public float yMax;


    void Start()
    {
        MyPlayer= GameObject.FindWithTag("Player").GetComponent<Player>();

        rball = GetComponent<Rigidbody2D>();

        rball.AddForce(new Vector2(bforce * 25f, bforce * 25f));

        MyPlayer.PUDelegate += Reduce;

    }

    void Update()
    {
        lastVelocity = rball.velocity;

        //--------to not destroy Green Ball on scene load
        if (gameObject.tag =="Green")
        {
            GameManager.instance.CheckStage(gameObject); 
        }
    }

    //Ball detection & consequences--------------------------------------------------------------------------------

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Green")
            {
                bonk = GetComponent<AudioSource>();
                GameManager.instance.CurrentScore(1f);
                bonk.Play();

                Respawn();
                Spawn(Red);
            }
            else if(gameObject.tag =="Red")
            {
                bonk = GetComponent<AudioSource>();               
                bonk.Play();
                coll.gameObject.GetComponent<Player>().GameOver();
            }
            {
                var speed = lastVelocity.magnitude;
                var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

                rball.velocity = direction * Mathf.Max(speed, 0f);
            }
        }

        else
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            rball.velocity = direction * Mathf.Max(speed, 0f);
        }
    }

    //Green Ball Respawn----------------------------------------------------------------------------------------

    private void Respawn()
    {
        transform.position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
    }

    //Red Ball spawn--------------------------------------------------------------------------------------------

    private void Spawn(GameObject Red)
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        Instantiate(Red, pos, Quaternion.identity);
    }

    //Skull Ball---------------------------------------------------------------------------------------------------
    private void Attack(GameObject Skull)
    {

    }

    //Power Up shrinks Red Balls-----------------------------------------------------------------------------------

    public void Reduce()
    {
            if (gameObject.tag == "Red")
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);              

                Invoke("Normalize", 10.0f);
            }
    }

    //Red Balls return to normal size------------------------------------------------------------------------------

    public void Normalize()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }


}