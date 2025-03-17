using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public ScoreScript score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);

            score.addScore(5);
        }
    }
}
