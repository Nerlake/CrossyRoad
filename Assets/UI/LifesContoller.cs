using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifesContoller : MonoBehaviour
{

    [SerializeField] private GameObject lifesUI;
    [SerializeField] private TMP_Text nbLifesText;
    [SerializeField] private GameObject player;
    private DeadControllerOfPlayer deadControllerOfPlayer;

    private void Start()
    {
        deadControllerOfPlayer = player.GetComponent<DeadControllerOfPlayer>();
        nbLifesText.SetText(deadControllerOfPlayer.lifes.ToString());
    }

    public void RemoveOneLife()
    {
        nbLifesText.SetText(deadControllerOfPlayer.lifes.ToString());
    }

    public void AddOneLife()
    {
        nbLifesText.SetText(deadControllerOfPlayer.lifes.ToString());
    }
}