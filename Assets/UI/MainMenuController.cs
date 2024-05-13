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

    private float initialSpeedVehicle = 2;
    private float initialSpeedLog = 4;

    public void ModeFacile()
    {
        btnFacile.interactable = false;
        btnMoyen.interactable = true;
        btnHard.interactable = true;

        initialSpeedVehicle = 2;
        initialSpeedLog = 4;
    }

    public void ModeMoyen()
    {
        btnFacile.interactable = true;
        btnMoyen.interactable = false;
        btnHard.interactable = true;

        initialSpeedVehicle = 4;
        initialSpeedLog = 8;
    }

    public void ModeHard()
    {
        btnFacile.interactable = true;
        btnMoyen.interactable = true;
        btnHard.interactable = false;

        initialSpeedVehicle = 8;
        initialSpeedLog = 16;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        LandGeneratorController.initialSpeedVehicle = initialSpeedVehicle;
        LandGeneratorController.initialSpeedLog = initialSpeedLog;
        SceneManager.LoadScene("GameStart");
    }
    public void SeeScores()
    {
        SceneManager.LoadScene("Scores");
    }
}