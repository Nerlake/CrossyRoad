using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public bool isPause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPause = !isPause;

        if (isPause)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void ClosePauseMenu()
    {
        isPause = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameStart");
    }

    public void MainMenu()
    {
        isPause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
}