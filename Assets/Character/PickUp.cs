using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;                  // The position the item will be held on the player
    public LayerMask pickUpMask;                // The layer where items are pickable
    public Vector3 Direction { get; set; }      // The direction the item will be dropped
    private GameObject itemHolding;             // The item being currently held

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))                                        // IF the key E was pressed
        {
            if (itemHolding)                                                        // IF an item is currently being held
            {
                itemHolding.transform.position = transform.position + Direction;        // Set its position to its current position plus a vector
                itemHolding.transform.parent = null;                                    // Stops being a child to our player
                if (itemHolding.GetComponent<Rigidbody2D>())                            // IF the item held has a rigid body
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;               // Sets the 2D physics to active (allows for re-pick up)
                itemHolding = null;                                                     // Sets the item held to nothing
            } else
            {                                                                       // If an item is currently NOT being held
                Collider2D pickUpItem = Physics2D.OverlapCircle(                    // Attempts to get an item near the player
                    transform.position + Direction*(1/4), .4f, pickUpMask);         
                if (pickUpItem)                                                         // IF the attempt was successful and an item was registered
                {
                    itemHolding = pickUpItem.gameObject;                                    // Sets the item currently being held to the registered item
                    itemHolding.transform.position = holdSpot.position;                     // Sets the held item's position to the player's hold position
                    itemHolding.transform.parent = transform;                               // Sets the held item to be a child of the player
                    if (itemHolding.GetComponent<Rigidbody2D>())                            // If the held item has a rigid body
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;              // Sets the 2D physics to inactive (allows for carrying)
                }
            }
        }
    }
}
