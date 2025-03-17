using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float timeToDestroy = 5f;
    public Rigidbody2D rb;
    public ScoreScript score;
    
    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(target.gameObject);
            score.addScore(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
