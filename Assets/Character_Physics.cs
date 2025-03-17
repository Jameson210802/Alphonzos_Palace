using UnityEngine;
using System.Collections;

public class Character_Physics : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    public float movementSpeed;
    private Vector2 moveDirection;
    private bool isGrounded;
    private Animator animator;
    [HideInInspector] public bool isFacingRight = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveDirection = Vector2.zero;
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Terrain"))
        {
		    isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("player_jump");
            myRigidbody.linearVelocity = Vector2.up * jumpStrength;
            isGrounded = false;
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("player_walking", true);
            moveDirection.x = -movementSpeed;
            if (isFacingRight) Flip();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("player_walking", true);
            moveDirection.x = movementSpeed;
            if (!isFacingRight) Flip();
        }
        else
        {
            animator.SetBool("player_walking", false);
            moveDirection.x = 0;
        }
        
        myRigidbody.linearVelocity = new Vector2(moveDirection.x, myRigidbody.linearVelocity.y);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;  // Flip the x-axis of the player
        transform.localScale = theScale;
    }
}
