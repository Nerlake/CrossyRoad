
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button btnFacile;
    [SerializeField] private Button btnMoyen;
    [SerializeField] private Button btnHard;
    [SerializeField] private GameObject themeMusic;
    [SerializeField] private GameObject UISecret;
    [SerializeField] private TMP_Text UISecretText;
    [SerializeField] private int secretPoint;
    [SerializeField] public int lifes;
    [SerializeField] public int maxLifes;


    [SerializeField] private AudioSource secretMusic;

    private float initialSpeedVehicle = 2;
    private float initialSpeedLog = 4;
    private AudioSource themeMusicAudioSource;


    public void ModeFacile()
    {
        btnFacile.interactable = false;
        btnMoyen.interactable = true;
        btnHard.interactable = true;

        initialSpeedVehicle = 2;
        initialSpeedLog = 4;
        PlayerPrefs.SetInt("lifes", 3);
        PlayerPrefs.SetInt("maxLifes", 3);

        PlayerPrefs.SetInt("difficulty", 1);
    }

    public void ModeMoyen()
    {
        btnFacile.interactable = true;
        btnMoyen.interactable = false;
        btnHard.interactable = true;

        initialSpeedVehicle = 4;
        initialSpeedLog = 8;

        PlayerPrefs.SetInt("lifes", 1);
        PlayerPrefs.SetInt("maxLifes", 1);

        PlayerPrefs.SetInt("difficulty", 2);
    }

    public void ModeHard()
    {
        btnFacile.interactable = true;
        btnMoyen.interactable = true;
        btnHard.interactable = false;

        initialSpeedVehicle = 6;
        initialSpeedLog = 12;

        PlayerPrefs.SetInt("lifes", 0);
        PlayerPrefs.SetInt("maxLifes", 1);

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
        themeMusicAudioSource = themeMusic.GetComponent<AudioSource>();
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

    void Update()
    {
        DetectShortcut();
        if(!themeMusicAudioSource.isPlaying && !secretMusic.isPlaying)
        {
            themeMusicAudioSource.Play();
            UISecret.SetActive(false);
        }
    }

    void DetectShortcut()
    {
        // Vérifie si Ctrl est enfoncé
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            // Vérifie si la touche L est enfoncée
            if (Input.GetKeyDown(KeyCode.L))
            {
                BonusSecret(secretPoint);
            }
        }
    }

    public void ResetGame()
    {
        UISecret.SetActive(true);
        UISecretText.SetText("Game Reset");
        PlayerPrefs.DeleteAll();
        InitScore();
        // desactive le secret ui dans 2 secondes
        Invoke("DisableSecretUI", 2);
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

    public void DisableSecretUI()
    {
        UISecret.SetActive(false);
    }

    private void BonusSecret(int pointsToAdd)
    {
        if (secretMusic.isPlaying) return;

        themeMusicAudioSource.Stop();
        secretMusic.Play();
        UISecretText.SetText(pointsToAdd.ToString() + " points unlocked");
        UISecret.SetActive(true);
        int cumul = PlayerPrefs.GetInt("cumulatedScore", 0);
        cumul += pointsToAdd;
        PlayerPrefs.SetInt("cumulatedScore", cumul);
    }
}