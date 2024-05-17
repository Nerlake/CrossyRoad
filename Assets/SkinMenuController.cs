using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text cumulatedScoreValue;

    void Start()
    {
        int score = PlayerPrefs.GetInt("cumulatedScore");
        cumulatedScoreValue.SetText(score.ToString());
    }
}
