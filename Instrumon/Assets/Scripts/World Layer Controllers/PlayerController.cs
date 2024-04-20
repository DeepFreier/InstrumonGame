using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    public LayerMask teleportLayer;
    private bool allowInput = true; // Flag to control whether input is allowed

    // Calls the function inside when the script is loaded
    private void Awake()
    {
        animator = GetComponent<Animator>(); // Grabs the animator from Unity and assigns the variable to it.
    }

    // Handles player movement and interaction
    public void HandleUpdate()
    {
        if (!isMoving && allowInput) // Process input only if not moving and input is allowed
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos)); // Moves the player using the targetPos variable
                }
                if (isTeleport(targetPos))
                {
                    var collider = Physics2D.OverlapCircle(targetPos, .2f, teleportLayer);
                    if (collider != null)
                    {
                        collider.GetComponent<Teleporter>()?.Teleport();
                    }
                }
            }
        }
        // Tells the animator that the player is moving
        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    // Handles player interaction with objects
    private void Interact()
    {
        //Calculates where the player is facing using the animator
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        //Calculates a position using the player's current position and the facingDir
        var interactPos = transform.position + facingDir;

        //Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        //Checks if something is there
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
            //Debug.Log("There is an NPC here!");
        }
    }

    // Checks if the player is about to teleport
    private bool isTeleport(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.2f, teleportLayer) != null;
    }

    // Coroutine to move the player smoothly
    IEnumerator Move(Vector3 targetPos)
    {
        // Tells the script the player is moving when this is called
        isMoving = true;

        // While the player is moving, this method moves the actual player avatar.
        // (targetPos - transform.position).sqrMagnitude > Mathf.Epsilon is just saying
        // that the player movement is greater than zero
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // Sets the player's position to where it should be using targetPos
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        // When the player is no longer moving, the script is told the player is no longer moving
        isMoving = false;
    }

    // Checks if the target position is walkable
    private bool IsWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) == null;
    }

    // Sets flag to ignore input
    public void IgnoreInput()
    {
        allowInput = false;
    }

    // Sets flag to allow input
    public void AllowInput()
    {
        allowInput = true;
    }
}
