using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject resumeButton;
    public GameObject optionsButton;
    public GameObject menuButton;
    public GameObject exitButton;
    public GameObject volumeSlider;
    public GameObject subtitlesCheckbox;
    public GameObject backButton;
    public bool pause = true;

    // Start is called before the first frame update
    void Start()
    {
        DisplayPauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            DisplayPauseMenu();
        }
    }

    public void DisplayPauseMenu()
    {
        if(pause)
        {
            pauseMenu.SetActive(false);
            pause = false;
            Time.timeScale = 1;
        }
        else if(!pause)
        {
            pauseMenu.SetActive(true);
            pause = true;
            Time.timeScale = 0;
            resumeButton.SetActive(true);
            optionsButton.SetActive(true);
            menuButton.SetActive(true);
            exitButton.SetActive(true);
            volumeSlider.SetActive(false);
            subtitlesCheckbox.SetActive(false);
            backButton.SetActive(false);
        }
    }

    public void Resume()
    {
        pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        resumeButton.SetActive(false);
        optionsButton.SetActive(false);
        menuButton.SetActive(false);
        exitButton.SetActive(false);
        volumeSlider.SetActive(true);
        subtitlesCheckbox.SetActive(true);
        backButton.SetActive(true);
    }

    public void Back()
    {
        resumeButton.SetActive(true);
        optionsButton.SetActive(true);
        menuButton.SetActive(true);
        exitButton.SetActive(true);
        volumeSlider.SetActive(false);
        subtitlesCheckbox.SetActive(false);
        backButton.SetActive(false);
    }

    public void Subtitles()
    {

    }

    public void Volume()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
