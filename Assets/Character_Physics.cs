using UnityEngine;
using System.Collections;

public class Character_Physics : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    public float movementSpeed;
    public AudioSource jumpSound;
    public AudioSource walkSound;

    private Vector2 moveDirection;
    private bool isGrounded;

    [HideInInspector] public bool isFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveDirection = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
            if (isGrounded && (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)))
            {
                walkSound.Play();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            walkSound.Stop();
            jumpSound.Play();
            myRigidbody.linearVelocity = Vector2.up * jumpStrength;
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -movementSpeed;
            if (isFacingRight) Flip();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = movementSpeed;
            if (!isFacingRight) Flip();
        }
        else
        {
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