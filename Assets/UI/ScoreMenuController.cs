using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text Hs1;
    [SerializeField] private TMP_Text Hs2;
    [SerializeField] private TMP_Text Hs3;
    [SerializeField] private TMP_Text Hs4;
    [SerializeField] private TMP_Text Hs5;

    public void Update()
    {
        Hs1.SetText(PlayerPrefs.GetString("HSPseudo1") + " - " + PlayerPrefs.GetInt("HSValue1"));
        Hs2.SetText(PlayerPrefs.GetString("HSPseudo2") + " - " + PlayerPrefs.GetInt("HSValue2"));
        Hs3.SetText(PlayerPrefs.GetString("HSPseudo3") + " - " + PlayerPrefs.GetInt("HSValue3"));
        Hs4.SetText(PlayerPrefs.GetString("HSPseudo4") + " - " + PlayerPrefs.GetInt("HSValue4"));
        Hs5.SetText(PlayerPrefs.GetString("HSPseudo5") + " - " + PlayerPrefs.GetInt("HSValue5"));
    }

    public void ExitToHome()
    {
        SceneManager.LoadScene("Home");
    }
}