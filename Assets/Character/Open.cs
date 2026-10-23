using UnityEngine;

public class Interact : MonoBehaviour
{

    [SerializeField] private GameObject Player;                             // Reference to the player object
    [SerializeField] private GameObject Keybind;                            // Reference to the keybind object
    private GameObject itemDetected;                                        // Reference to the item object

    private void OnTriggerEnter2D(Collider2D collision)             
    {
        itemDetected = Player.GetComponent<PickUp>().itemHolding;           // Gets a reference copy of the itemHolding found in Player object
        Player.GetComponent<PickUp>().isNextToInteractable = true;          // Disables PickUp script in Player object
        Keybind.SetActive(true);                                            // Displays a keybind needed to press for interaction
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemDetected)                    // If the key being pressed is E AND an item is being held
        {
            if (itemDetected.CompareTag("Key"))                             // Compare the tag of held item to "Key"
            {
                Destroy(itemDetected);                                      // and attempt to destroy the held item
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        itemDetected = null;                                                // Sets the item being held to null
        Player.GetComponent<PickUp>().isNextToInteractable = false;         // Enables PickUp script in Player object
        Keybind.SetActive(false);                                           // Hides the keybind needed (not in range)
    }

}
