using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public static ScoreScript Instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make the GameObject persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    // This ensures that the ScoreScript persists across scenes
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persist across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
}
