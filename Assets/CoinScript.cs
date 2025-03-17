using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource collectCoin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            collectCoin.Play();
            Destroy(gameObject);
        }
    }
}
