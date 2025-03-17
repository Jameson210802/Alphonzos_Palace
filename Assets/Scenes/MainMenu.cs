using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource titleBGM;
    public AudioSource checkpointZeroBGM;

    public void PlayGame()
    {
        titleBGM.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        checkpointZeroBGM.Play();
    }

    public void QuitGame()
    {
        titleBGM.Stop();
        Application.Quit();
    }
}