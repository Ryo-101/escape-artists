using UnityEngine;

public class Type : MonoBehaviour
{

    public GameObject Player;                               // Reference to the player object
    public GameObject Keybind;                              // Reference to the keybind object
    public GameObject Keypad;
    private bool isNextTo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.GetComponent<PickUp>().isNextToInteractable = true;          // Disables PickUp script in Player object
        Keybind.SetActive(true);                                            // Displays a keybind needed to press for interaction
        isNextTo = true;
    }

    private void Update()
    {
        if (isNextTo && Input.GetKeyDown(KeyCode.E))                                    // If the key being pressed is E AND an item is being held
        {
            Keypad.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player.GetComponent<PickUp>().isNextToInteractable = false;         // Enables PickUp script in Player object
        Keybind.SetActive(false);                                           // Hides the keybind needed (not in range)
        Keypad.SetActive(false);
        isNextTo = false;
    }

}
