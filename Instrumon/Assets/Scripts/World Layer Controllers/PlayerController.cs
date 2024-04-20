using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private bool isMoving;

    //Input from the player is assigned into this variable
    private Vector2 input;

    //How the script pass info to the animator for the player sprite
    private Animator animator;

    public LayerMask solidObjectsLayer;

    public LayerMask interactableLayer;

    public LayerMask teleportLayer;

    [SerializeField]
    public List<Instrumon> playerparty;

    public int playerlevel;

    //Calls the function inside when the script is loaded
    private void Awake()
    {
        //Grabs the animator from Unity and assigns the variable to it.
        animator = GetComponent<Animator>();
    }

   
    public void UpdateParty()
    {
        foreach (var instrumon in playerparty)
        {
            instrumon.LevelSet(playerlevel);
            Debug.Log(instrumon.level);
            instrumon.Base.MaxHP = instrumon.MaxHP;
            instrumon.Base.Attack = instrumon.Attack;
            instrumon.Base.Speed = instrumon.Speed;
            Debug.Log("Instrumon name: " + instrumon.Base.Name);
            Debug.Log("Instrumon MaxHP: " + instrumon.Base.MaxHP);
            Debug.Log("Instrumon current HP: " + instrumon.Base.CurrentHP);
        }
        Debug.Log("Party Updated");
    }


    public void HandleUpdate()
    {
        //Checks if the player is moving
        if (!isMoving)
        {
            //Stores the input from the player into the input variable for later use
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            //Debug.Log("This is input.x" + input.x);
            //Debug.Log("This is input.y" + input.y);



            //Stops the player moving diagonally, as we don't have a diagonal animation
            if (input.x != 0) input.y = 0;

            //Stores the input as a targetPos variable to give to the function
            //that moves the player avatar
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                {
                    //Moves the player using the targetPos variable
                    StartCoroutine(Move(targetPos));
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
        //Tells the animator that the player is moving
        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }



    //The method for the interact key.
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

    private bool isTeleport(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, teleportLayer) != null)
        {
            return true;
        }

        return false;
    }

    


    IEnumerator Move(Vector3 targetPos)
    {
        //Tells the script the player is moving when this is called
        isMoving = true;

        //While the player is moving this method moves the actual player avatar.
        //(targetPos - transform.position).sqrMagnitude > Mathf.Epsilon is just saying
        //that the player movement is greater than zero
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //Sets the player's position to where it should be using targetPos
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        //When the player is no longer moving the script is told the player is no longer moving
        isMoving = false;
    }

    

    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }

        return true;
    }
}
