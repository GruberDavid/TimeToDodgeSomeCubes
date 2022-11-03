using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Player_Inventory inventory;
    private int nbCollision = 0;

    public Life life;

    public AudioSource myAudio;
    public AudioClip collisionSound;
    public ObstacleMovement obstacleMovement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Obstacle")))
        {
            myAudio.PlayOneShot(collisionSound);
            nbCollision++;
            movement.disableCollision();
            movement.enabled = false;

            Item item = inventory.GetActivatedItem();

            if (item != null)
            {
                if (item.use_effect() == 1 && item.getName() == "Item_Life")
                {
                    if (item.getUsed() >= item.getRarity())
                        inventory.items.Remove(item);

                    life.SetLife(life.lifePoints-1);
                    movement.enabled = true;
                    Destroy(collision.gameObject);
                    movement.enableCollision();
                    return;
                }
            }

            inventory.Drop_item();
            obstacleMovement.speed = 20f;

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
