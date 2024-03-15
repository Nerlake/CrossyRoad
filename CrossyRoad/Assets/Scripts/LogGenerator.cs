using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogGenerator : MonoBehaviour
{
    [SerializeField] private GameObject logPrefab;
    [SerializeField] private int minPosition;
    [SerializeField] private int maxPosition;
    [SerializeField] private int logCount;
    private bool isRightSpawner;

    void Start()
    {
        System.Random random = new System.Random();

        isRightSpawner = random.Next(0, 2) == 1;
        for (int i=0; i<logCount; i++)
        {
            float startingPosition;
            if(isRightSpawner)
            {
                startingPosition = maxPosition;
            }
            else
            {
                startingPosition = minPosition;
            }
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, startingPosition);
            Instantiate(logPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
