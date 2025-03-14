using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float bounce;         // Bounce force on collision
    public Rigidbody2D rb2D;     // Rigidbody for the player
    public int lives = 3;        // Starting lives of the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // You can initialize values here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // You can handle health-based conditions, such as game over logic
        if (lives <= 0)
        {
            // Handle game over logic (e.g., restart the level or show a game over screen)
            Debug.Log("Game Over!");
        }
    }

    // Trigger collision with Goblin
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Decrease player's lives
            lives--;

            // Add a bounce effect to the player
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, bounce);

            // Debug for checking health/lives status
            Debug.Log("Lives left: " + lives);
        }
    }
}