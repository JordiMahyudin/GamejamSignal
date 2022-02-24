using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;


    private bool isPaused;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //kijkt of pause aan staat zo niet zet de game hem op pause
            if (isPaused)
            {
                optionsMenu.SetActive(false);
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        //zet het spel op pauze door de tijd op 0 te zetten
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menuscherm");
    }

    public void Next()
    {
        SceneManager.LoadScene("level1");
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartMain()
    {
        SceneManager.LoadScene("level1");
    }
}
