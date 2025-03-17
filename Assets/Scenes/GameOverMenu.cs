using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource titleBGM;
    public AudioSource checkpointZeroBGM;

    public void PlayGame()
    {
        SceneManager.LoadScene("The Gauntlet");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
