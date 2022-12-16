using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private Vector3 offset = new Vector3(1f, 5.5f, -10f);
    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.15f;

    [SerializeField] private Transform target;

    void Update()
    {
        GameManager.instance.CheckStage(gameObject);

        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

}
