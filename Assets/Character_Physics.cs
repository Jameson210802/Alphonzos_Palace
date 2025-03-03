using UnityEngine;
using System.Collections;

public class Character_Physics : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    public float movementSpeed;
    private Vector2 moveDirection;
    private bool isGrounded;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveDirection = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.linearVelocity = Vector2.up * jumpStrength;
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = movementSpeed;
        }
        else
        {
            moveDirection.x = 0;
        }

        myRigidbody.linearVelocity = new Vector2(moveDirection.x, myRigidbody.linearVelocity.y);
    }
}
