using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float bounce;         // Bounce force on collision
    public Rigidbody2D rb2D;     // Rigidbody for the player
    public int lives;        // Starting lives of the player
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public AudioSource playerDamaged;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // You can initialize values here if needed
    }

    // Update is called once per frame
    void Update()
    {
        switch (lives)
        {
            case 0:
            {
                Heart1.gameObject.SetActive(false);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                Debug.Log("Game Over!");
                break;
            }
            case 1:
            {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);
                break;
            }
            case 2:
            {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);
                break;
            }
            case 3:
            {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
                break;
            }
        }
    }

    // Trigger collision with Goblin
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerDamaged.Play();
            // Decrease player's lives
            lives--;

            // Add a bounce effect to the player
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, bounce);

            // Debug for checking health/lives status
            Debug.Log("Lives left: " + lives);
        }
    }
}