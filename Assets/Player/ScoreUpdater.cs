using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private ScoreController scoreController;
    private void Start()
    {
        scoreController = GameObject.Find("txtScore").GetComponent<ScoreController>();
    }

    private void Update()
    {
        scoreController.currentPosZ = transform.position.z;
    }
}
