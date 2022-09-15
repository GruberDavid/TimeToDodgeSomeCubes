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
        if (collision.gameObject.CompareTag(("Obstacle")))
        {
            Debug.Log("NB COLLISION : " + nbCollision);
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

                    movement.enabled = true;
                    Destroy(collision.gameObject);
                    movement.enableCollision();
                    Debug.Log("\nCA REPART\n");
                    return;
                }
            }

            inventory.Drop_item();

            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
