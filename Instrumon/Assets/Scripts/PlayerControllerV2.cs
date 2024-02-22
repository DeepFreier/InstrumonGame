using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float horizontalInput;
    public float verticalInput;
    public SpriteRenderer spriteRenderer;
    private Animator animator = null;
    [SerializeField]
    public float PlayerSpeed;


    //public GameObject player;


    // Start is called before the first frame update

    //public AudioSource AudioManager;
    //public AudioClip WalkingSound;
    void Start()
    {
        PlayerSpeed = 1.5f;
        spriteRenderer.flipX = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else if (verticalInput < 0)
        {
            spriteRenderer.flipY = false;
            animator.SetBool("isRunning", true);
        }
        else if (verticalInput > 0)
        {
            spriteRenderer.flipY = true;
            animator.SetBool("isRunning", true);
        }
        else if (horizontalInput == 0 && verticalInput == 0)
        {
            animator.SetBool("isRunning", false);
        }




        //DontDestroyOnLoad(this.gameObject);
    }
    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(horizontalInput * PlayerSpeed, playerRB.velocity.y);
    }
}
