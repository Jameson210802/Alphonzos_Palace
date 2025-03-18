using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScoreScript : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // Access the ScoreScript singleton instance
        if (ScoreScript.Instance != null)
        {
            string finalScore = ScoreScript.Instance.playerScore.ToString();
            scoreText.text = "Final Score: " + finalScore;
        }
        else
        {
            Debug.LogError("ScoreScript instance not found.");
        }
    }
}
