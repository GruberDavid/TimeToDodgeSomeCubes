using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Obstacle"))
        {
            movement.enabled = false;
            Debug.Log("Et pef!");
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
