using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Goblin_Health : MonoBehaviour
{
    public int maxHealth = 2; // maxhealth
    public int currentHealth; //used for calculating health. 

    public AudioSource goblinDamaged;
    public AudioSource goblinDead;
  
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int amount) // need to test
    {
        goblinDamaged.Play();
        currentHealth -= amount;
        Enemy_Back_and_Forth enemyMovement = GetComponent<Enemy_Back_and_Forth>();
        if (currentHealth <= 0)   // Destroys object if out of health. 
        {
            goblinDead.Play();
            animator.SetBool("goblin_dead", true); // trigers death animation. 

            //GetComponent<Collider2D>().enabled = false; // Disable collision
            enemyMovement.movement_speed = 0f;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; // Stop physics movement



            Destroy(gameObject, 1.5f); 
        
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            goblinDead.Play();
        }
    }
}
