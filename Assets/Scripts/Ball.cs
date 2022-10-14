using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float bforce = 9.8f;
    private Rigidbody2D rball;

    Vector3 lastVelocity;

    void Start()
    {
        rball = GetComponent<Rigidbody2D>();
        rball.AddForce(new Vector2(bforce * 25f, bforce * 25f));
    
    }


    void Update()
    {
        lastVelocity = rball.velocity;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rball.velocity = direction * Mathf.Max(speed, 0f);
    }
}
