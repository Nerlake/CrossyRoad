using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatController : MonoBehaviour
{
    public GameObject playerOnMe;

    private void Update()
    {
        if (playerOnMe)
        {
            playerOnMe.transform.position = transform.position;
        }
    }
}