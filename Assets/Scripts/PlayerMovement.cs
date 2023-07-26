using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded = true;
    public Rigidbody rb;
    public float sideForce = 200f;
    public float jumpForce = 500f;
    public AudioSource myAudio;
    public AudioClip jumpSound;



    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            isGrounded = false;
            //play jump sound
            myAudio.PlayOneShot(jumpSound);

        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }

    public void disableCollision()
    {
        rb.detectCollisions = false;
        rb.isKinematic = true;
    }

    public void enableCollision()
    {
        rb.detectCollisions = true;
        rb.isKinematic = false;
    }
}
