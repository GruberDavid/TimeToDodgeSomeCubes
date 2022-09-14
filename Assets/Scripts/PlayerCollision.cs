using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Player_Inventory inventory;
    private int nbCollision = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Obstacle"))
        {
            Debug.Log("NB COLLISION : " + nbCollision);
            nbCollision++;
            movement.disableCollision();
            movement.enabled = false;

            Item item = inventory.getActivatedItem();

            if (item != null)
            {
                if (item.use_effect() == 1 && item.getName() == "Item_Life")
                {
                    movement.enabled = true;
                    Destroy(collision.gameObject);
                    movement.enableCollision();
                    Debug.Log("\nCA REPART\n");
                    return;
                }
            }

            inventory.drop_item();

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
