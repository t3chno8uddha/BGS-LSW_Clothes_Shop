using UnityEngine;

public class PlayerNavigation : MonoBehaviour
{
    [HideInInspector] public bool isConversing = false;

    public string characterName; // Character name.
    public float movementSpeed; // Character movement speed.

    bool isMoving = false; // Whether the player is moving.
    Vector2 playerInput; // Player movement input.
    Animator playerAnimator; // Player sprite sheet animator

    Rigidbody2D rb; // Player physics.

    void Start()
    {
        // Get the player components
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Get player input and animate the player.
        if (!isConversing)
        {
            GetInput();
        }
        else
        {
            playerInput = Vector2.zero;
        }

        AnimatePlayer();
    }

    void FixedUpdate()
    {
        // Move the player in Fixed Time.
        Move();
    }

    void GetInput()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");

        // Normalize the input for diagonal movement.
        playerInput = playerInput.normalized;
    }

    void Move()
    {
        if (playerInput != Vector2.zero)
        {
            // If there's input, set isMoving to true and move the player.
            isMoving = true;
            rb.position = transform.position + (Vector3)playerInput * movementSpeed * Time.deltaTime;
        }
        else
        {
            // If there's no input, don't.
            isMoving = false;
        }
    }

    void AnimatePlayer()
    {
        // Set the animator parameters based on the player's input direction.
        playerAnimator.SetFloat("Vertical Input", playerInput.y);
        playerAnimator.SetFloat("Horizontal Input", playerInput.x);

        // Set the "Is Moving" parameter in the animator based on whether the player is moving or not.
        playerAnimator.SetBool("Is Moving", isMoving);
    }
}
