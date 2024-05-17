using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreController : MonoBehaviour
{
    public float currentPosZ;

    private TMP_Text txtScore;
    public int scorePieces;

    private void Start()
    {
        txtScore = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (Mathf.Round(float.Parse(txtScore.text)) < currentPosZ + scorePieces)
        {
            txtScore.SetText(Mathf.Round(currentPosZ) + scorePieces + "");
        }
    }

    public void AddScore(int score)
    {
        scorePieces += score;
    }


}