using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button btnFacile;
    [SerializeField] private Button btnMoyen;
    [SerializeField] private Button btnHard;

    private float initialSpeed = 2;

    public void ModeFacile()
    {
        btnFacile.interactable = false;
        btnMoyen.interactable = true;
        btnHard.interactable = true;

        initialSpeed = 2;
    }

    public void ModeMoyen()
    {
        btnFacile.interactable = true;
        btnMoyen.interactable = false;
        btnHard.interactable = true;

        initialSpeed = 5;
    }

    public void ModeHard()
    {
        btnFacile.interactable = true;
        btnMoyen.interactable = true;
        btnHard.interactable = false;

        initialSpeed = 10;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        LandGeneratorController.initialSpeed = initialSpeed;
        SceneManager.LoadScene("GameStart");
    }
}