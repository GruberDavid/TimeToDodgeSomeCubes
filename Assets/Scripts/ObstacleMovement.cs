using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

}
