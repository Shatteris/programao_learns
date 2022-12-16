using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUps : MonoBehaviour
{ 

    private float waitTime = 10.0f;
    private float timer = 0.0f;
    public GameObject Prefab;


    // the range of X
    public float xMin;
    public float xMax;

    // the range of y
    public float yMin;
    public float yMax;

    void Start()
    {

    }

    void Update()
    {
        GameManager.instance.CheckStage(gameObject);

        //PowerUp Timer
        timer += Time.deltaTime;

            if (timer >= waitTime && Prefab != null)
            {
                Spawn(Prefab);
                timer = 0.0f;
                Prefab = null;
            }      
    }

    // spawn PowerUp
    private void Spawn(GameObject PowerUp)
    {
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(PowerUp, pos, Quaternion.identity);
    }

}
