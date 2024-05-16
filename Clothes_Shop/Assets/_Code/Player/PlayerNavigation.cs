using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigation : CharacterBehaviour
{
    bool isMoving = false;
    Vector2 playerInput;
    public Animator playerAnimator; // The sprite sheet animator

    void Update()
    {
        GetInput();

        Move();
        AnimatePlayer();
    }

    void GetInput()
    {
        playerInput.x = Input.GetAxisRaw ("Horizontal");
        playerInput.y = Input.GetAxisRaw ("Vertical");

        playerInput = playerInput.normalized;
    }

    void Move()
    {
        if (playerInput != Vector2.zero)
        {
            isMoving = true;
            transform.position += (Vector3)playerInput * movementSpeed * Time.deltaTime;
        }
        else
        {
            isMoving = false;
        }
    }

    void AnimatePlayer()
    {
        playerAnimator.SetFloat("Vertical Input", playerInput.y);
        playerAnimator.SetFloat("Horizontal Input", playerInput.x);

        playerAnimator.SetBool("Is Moving", isMoving);
    }
}