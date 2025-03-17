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
        DontDestroyOnLoad(checkpointZeroBGM);
        checkpointZeroBGM.Play();
        SceneManager.LoadScene("The Gauntlet");
    }

    public void QuitGame()
    {
        titleBGM.Stop();
        Application.Quit();
    }
}