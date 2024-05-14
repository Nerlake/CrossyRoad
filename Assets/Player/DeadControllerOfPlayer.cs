using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DeadControllerOfPlayer : MonoBehaviour
{
    private float totalTimeIdleSinceLastMoveOnZ;
    private float maxTimeBeforeDead = 10f;
    private float lastPositionOnZ;
    private float timeBeforeCheckAgainIsDeath = 0.1f;
    private float timeSinceLastDeath = 0f;

    private LifesContoller lifeController;

    private bool ghostMode = false;
    private Animator animator;

    private ScoreController scoreController;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text lblYourScore;
    [SerializeField] private TMP_Text inputPseudo;
    [SerializeField] private AudioSource splashSound;
    [SerializeField] private AudioSource crashSound;
    [SerializeField] private AudioSource outOfPovSound;



    private PauseMenuController pauseMenuController;

    private void Start()
    {
        lastPositionOnZ = transform.position.z;
        lifeController = GameObject.Find("lifes").GetComponent<LifesContoller>();
        animator = GetComponent<Animator>();
        scoreController = GameObject.Find("txtScore").GetComponent<ScoreController>();
        pauseMenuController = GameObject.Find("UI").GetComponent<PauseMenuController>();
    }

    private void Update()
    {
        if (ghostMode)
        {
            animator.SetTrigger("GhostMode");
        }

        timeSinceLastDeath += Time.deltaTime;

        ManageIdleTime();
        ManageCollisionWithRiver();
    }

    private void ManageCollisionWithRiver()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            if (hit.collider.CompareTag("River"))
            {
                OnDeadBecauseFallInRiver();
            }
        }
    }

    private void ManageIdleTime()
    {
        totalTimeIdleSinceLastMoveOnZ += Time.deltaTime;

        if (transform.position.z > lastPositionOnZ)
        {
            totalTimeIdleSinceLastMoveOnZ = 0;
            lastPositionOnZ = transform.position.z;
        }

        if (totalTimeIdleSinceLastMoveOnZ >= maxTimeBeforeDead)
        {
            OnDeadBecauseTooIdle();
        }
    }

    private void OnDeadBecauseFallInRiver()
    {
        if (ghostMode) return;

        if (timeSinceLastDeath <= timeBeforeCheckAgainIsDeath) return;

        splashSound.Play();
        print("DeadControllerOfPlayer: Le joueur meurt car il est tombé dans la rivière");

        if (lifeController.RemoveOneLife())
        {
            timeSinceLastDeath = 0f;
            ghostMode = true;
        }
        else
        {
            PrepareAndShowGameOverScreen();
        }
        // EditorApplication.isPlaying = false;
    }

    private void OnDeadBecauseTooIdle()
    {
        if (timeSinceLastDeath < timeBeforeCheckAgainIsDeath) return;

        print("DeadControllerOfPlayer: Le joueur meurt car il est resté trop longtemps inactif");
        if (lifeController.RemoveOneLife())
        {
            timeSinceLastDeath = 0f;
            totalTimeIdleSinceLastMoveOnZ = 0;
        }
        else
        {
            PrepareAndShowGameOverScreen();
        }
        // EditorApplication.isPlaying = false;
    }

    public void OnDeadBecauseOutsideOfFov()
    {
        if (timeSinceLastDeath < timeBeforeCheckAgainIsDeath) return;

        outOfPovSound.Play();

        print("DeadControllerOfPlayer: Le joueur meurt car il n'est plus dans la FOV");

        PrepareAndShowGameOverScreen();
        // EditorApplication.isPlaying = false;
    }

    public void OnDeadBecauseVehicleCollision()
    {
        if (ghostMode) return;

        print("DeadControllerOfPlayer: Le joueur meurt car il se fait percuté par un véhicule");
        crashSound.Play();

        if (lifeController.RemoveOneLife())
        {
            timeSinceLastDeath = 0f;
            ghostMode = true;
        }
        else
        {
            PrepareAndShowGameOverScreen();
        }
        // EditorApplication.isPlaying = false;
    }

    public void ResetTimeSinceLastDeathAndGhostMode()
    {
        ghostMode = false;
        timeSinceLastDeath = 0;
    }

    private void PrepareAndShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        lblYourScore.SetText("Your score is " + Mathf.Max((int)scoreController.currentPosZ, 0));
        pauseMenuController.isPause = true;
    }

    public void OnValiderScore()
    {
        int score = Mathf.Max((int)scoreController.currentPosZ, 0);
        string pseudo = inputPseudo.text;

        addScoreToBoard(score, pseudo);

        SceneManager.LoadScene("Home");
    }

    public void addScoreToBoard(int score, string pseudo)
    {
        if (score > PlayerPrefs.GetInt("HSValue1"))
        {
            PlayerPrefs.SetInt("HSValue5", PlayerPrefs.GetInt("HSValue4"));
            PlayerPrefs.SetString("HSPseudo5", PlayerPrefs.GetString("HSPseudo4"));
            PlayerPrefs.SetInt("HSValue4", PlayerPrefs.GetInt("HSValue3"));
            PlayerPrefs.SetString("HSPseudo4", PlayerPrefs.GetString("HSPseudo3"));
            PlayerPrefs.SetInt("HSValue3", PlayerPrefs.GetInt("HSValue2"));
            PlayerPrefs.SetString("HSPseudo3", PlayerPrefs.GetString("HSPseudo2"));
            PlayerPrefs.SetInt("HSValue2", PlayerPrefs.GetInt("HSValue1"));
            PlayerPrefs.SetString("HSPseudo2", PlayerPrefs.GetString("HSPseudo1"));

            PlayerPrefs.SetInt("HSValue1", score);
            PlayerPrefs.SetString("HSPseudo1", pseudo);
        }
        else if (score > PlayerPrefs.GetInt("HSValue2"))
        {
            PlayerPrefs.SetInt("HSValue5", PlayerPrefs.GetInt("HSValue4"));
            PlayerPrefs.SetString("HSPseudo5", PlayerPrefs.GetString("HSPseudo4"));
            PlayerPrefs.SetInt("HSValue4", PlayerPrefs.GetInt("HSValue3"));
            PlayerPrefs.SetString("HSPseudo4", PlayerPrefs.GetString("HSPseudo3"));
            PlayerPrefs.SetInt("HSValue3", PlayerPrefs.GetInt("HSValue2"));
            PlayerPrefs.SetString("HSPseudo3", PlayerPrefs.GetString("HSPseudo2"));

            PlayerPrefs.SetInt("HSValue2", score);
            PlayerPrefs.SetString("HSPseudo2", pseudo);
        }
        else if (score > PlayerPrefs.GetInt("HSValue3"))
        {
            PlayerPrefs.SetInt("HSValue5", PlayerPrefs.GetInt("HSValue4"));
            PlayerPrefs.SetString("HSPseudo5", PlayerPrefs.GetString("HSPseudo4"));
            PlayerPrefs.SetInt("HSValue4", PlayerPrefs.GetInt("HSValue3"));
            PlayerPrefs.SetString("HSPseudo4", PlayerPrefs.GetString("HSPseudo3"));

            PlayerPrefs.SetInt("HSValue3", score);
            PlayerPrefs.SetString("HSPseudo3", pseudo);
        }
        else if (score > PlayerPrefs.GetInt("HSValue4"))
        {
            PlayerPrefs.SetInt("HSValue5", PlayerPrefs.GetInt("HSValue4"));
            PlayerPrefs.SetString("HSPseudo5", PlayerPrefs.GetString("HSPseudo4"));

            PlayerPrefs.SetInt("HSValue4", score);
            PlayerPrefs.SetString("HSPseudo4", pseudo);
        }
        else if (score > PlayerPrefs.GetInt("HSValue5"))
        {
            PlayerPrefs.SetInt("HSValue5", score);
            PlayerPrefs.SetString("HSPseudo5", pseudo);
        }
    }   
}