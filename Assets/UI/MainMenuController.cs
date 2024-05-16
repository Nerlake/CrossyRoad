
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

        PlayerPrefs.SetInt("difficulty", 1);
    }

    public void ModeMoyen()
    {
        btnFacile.interactable = true;
        btnMoyen.interactable = false;
        btnHard.interactable = true;

        initialSpeedVehicle = 4;
        initialSpeedLog = 8;

        PlayerPrefs.SetInt("difficulty", 2);
    }

    public void ModeHard()
    {
        btnFacile.interactable = true;
        btnMoyen.interactable = true;
        btnHard.interactable = false;

        initialSpeedVehicle = 8;
        initialSpeedLog = 16;

        PlayerPrefs.SetInt("difficulty", 3);
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
        SceneManager.LoadScene("Score");
    }

    public void SkinSelection()
    {
        SceneManager.LoadScene("SkinSelection");
    }

    public void Start()
    {
        InitScore();

        int defaultDifficulty = PlayerPrefs.GetInt("difficulty", 1);

        switch (defaultDifficulty)
        {
            case 1:
                ModeFacile();
                break;
            case 2:
                ModeMoyen();
                break;
            case 3:
                ModeHard();
                break;
        }
    }
    public void InitScore()
    {
        if (!PlayerPrefs.HasKey("HSValue1"))
        {
            PlayerPrefs.SetInt("HSValue1", 250);
            PlayerPrefs.SetString("HSPseudo1", "Kiryu");
        }

        if (!PlayerPrefs.HasKey("HSValue2"))
        {
            PlayerPrefs.SetInt("HSValue2", 200);
            PlayerPrefs.SetString("HSPseudo2", "Majima");
        }

        if (!PlayerPrefs.HasKey("HSValue3"))
        {
            PlayerPrefs.SetInt("HSValue3", 150);
            PlayerPrefs.SetString("HSPseudo3", "Daigo");
        }

        if (!PlayerPrefs.HasKey("HSValue4"))
        {
            PlayerPrefs.SetInt("HSValue4", 100);
            PlayerPrefs.SetString("HSPseudo4", "Date");
        }

        if (!PlayerPrefs.HasKey("HSValue5"))
        {
            PlayerPrefs.SetInt("HSValue5", 50);
            PlayerPrefs.SetString("HSPseudo5", "Haruka");
        }
    }
}