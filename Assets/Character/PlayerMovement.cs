using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;              // The movement speed of the player
    private Rigidbody2D rb;                                     // The rigid body of the player
    private Vector2 moveInput;                                  // The current move input of the player
    private Animator animator;                                  // The animator of the player
    private PickUp pickUp;                                      // The pickup component of the player

    void Start()                                                // Defines the declared variables above
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, -1) * 0.3f;           // Sets the direction to be below the player
    }

    void Update()                                               // Keeps up a constant movement
    {
        rb.linearVelocity = moveInput * moveSpeed;              
    }

    public void Move(InputAction.CallbackContext context)       // If the move input is active
    {
        animator.SetBool("isWalking", true);                        // Sets the animation state to walking

        if (context.canceled)                                       // If the move input becomes inactive
        {
            animator.SetBool("isWalking", false);                       // Sets the animation state to idle
        }

        moveInput = context.ReadValue<Vector2>();                   // Sets the move input to values read
        animator.SetFloat("InputX", moveInput.x);                   // Sets the animation frame to read x value
        animator.SetFloat("InputY", moveInput.y);                   // Sets the animation frame to read y value
    }
}
