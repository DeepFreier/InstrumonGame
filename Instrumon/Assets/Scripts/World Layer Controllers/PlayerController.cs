using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement variables
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;

    // Layer masks for collision detection
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    public LayerMask teleportLayer;

    // Flag to control whether input is allowed
    private bool allowInput = true;

    // List of Instrumon in the player's party and player level
    public List<Instrumon> playerparty;
    public int playerlevel;

    // Calls the function inside when the script is loaded
    private void Awake()
    {
        // Grabs the animator from Unity and assigns the variable to it
        animator = GetComponent<Animator>();
    }

    // Updates the player's party
    public void UpdateParty()
    {
        foreach (var instrumon in playerparty)
        {
            instrumon.LevelSet(playerlevel);
            if (playerlevel != 1) 
            {
                instrumon.level = playerlevel;
                instrumon.Base.MaxHP = instrumon.MaxHP;
                instrumon.Base.Attack = instrumon.Attack;
                instrumon.Base.Speed = instrumon.Speed;
            }
            else
            {
                instrumon.level = playerlevel;
                instrumon.Base.MaxHP = instrumon.Base.basemaxHP;
                instrumon.Base.Attack = instrumon.Base.baseattack;
                instrumon.Base.Speed = instrumon.Base.basespeed;
            }
            
        }
        Debug.Log("Party Updated");
    }

    public void healparty()
    {
        foreach (var instrumon in playerparty)
        {
            instrumon.Base.CurrentHP = instrumon.Base.MaxHP;
            Debug.Log(instrumon.Base.CurrentHP);
        }
    }

    // Handles player input and movement
    public void HandleUpdate()
    {
        if (!isMoving && allowInput) // Process input only if not moving and input is allowed
        {
            // Store input from the player
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Stop the player from moving diagonally
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                // Set animator parameters
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                // Calculate target position
                var targetPos = transform.position + new Vector3(input.x, input.y, 0);

                // Move the player if the target position is walkable
                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }

                // Teleport the player if applicable
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

        // Set animator parameter for player movement
        animator.SetBool("isMoving", isMoving);

        // Handle player interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    // Handles player interaction with objects
    private void Interact()
    {
        // Calculate interaction position based on player's facing direction
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        // Check if something is interactable at the calculated position
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
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
        isMoving = true; // Set moving flag

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // Move the player towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos; // Ensure the player is exactly at the target position
        isMoving = false; // Reset moving flag
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
