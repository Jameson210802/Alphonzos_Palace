using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public float timeToDestroy = 5f;
    public Rigidbody2D rb;
    
    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = Vector2.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(target.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
