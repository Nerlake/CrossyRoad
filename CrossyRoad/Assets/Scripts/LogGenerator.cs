using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LogGenerator : MonoBehaviour
{
    [SerializeField] private GameObject logPrefab;
    [SerializeField] private int minPosition;
    [SerializeField] private int maxPosition;
    [SerializeField] private int logDelay;
    [SerializeField] private int logSpeed;
    private bool isRightSpawner;

    System.Random random = new System.Random();
    void Start()
    {
        isRightSpawner = random.Next(0, 2) == 1;
    }
    
    private void Update()
    {        
        double delay = random.Next(0,10000);

        while(delay < logDelay)
        {
            Thread.Sleep(300);
            delay*=1.2;
        }

        float startingPosition = isRightSpawner ? maxPosition : minPosition;

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, startingPosition);
        Instantiate(logPrefab, spawnPosition, Quaternion.identity);
    }
}
