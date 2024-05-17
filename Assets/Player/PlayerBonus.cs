using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonus : MonoBehaviour
{

    private DeadControllerOfPlayer deadController;
    private ScoreController scoreController;
    [SerializeField] private GameObject UI;
    [SerializeField] private AudioSource gettingHearthSound;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] public int coinScore;
    // Start is called before the first frame update
    void Start()
    {
        deadController =  GetComponent<DeadControllerOfPlayer>();
        scoreController = UI.GetComponent<ScoreController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hearth"))
        {
            if (deadController.AddOneLife())
            {
                gettingHearthSound.Play();
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("Coin"))
        {
            Debug.Log("+1 Coin");
            coinSound.Play();
            Destroy(other.gameObject);
            scoreController.AddScore(coinScore);
        }
    }
}
