using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    private bool isPaused = false;
    public AudioManager audioManager;


    public void Awake()
    {
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Resume()
    {


        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        AudioManager.instance.unpauseSounds();


    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        if (!isPaused)
        {

            pauseButton.SetActive(false);
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            AudioManager.instance.pauseSounds();
           

        }
        else
        {
            Resume();

        }


        

    }

}
