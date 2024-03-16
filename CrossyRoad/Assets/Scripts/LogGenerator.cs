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
    private List<GameObject> logList = new List<GameObject>();
    private bool isRightSpawner;

    System.Random random = new System.Random();
    void Start()
    {
        isRightSpawner = random.Next(0, 2) == 1;
    }
    
    private void Update()
    {        
        foreach(GameObject log in logList)
        {
            log.transform.position += isRightSpawner ? new Vector3(0, -logSpeed, 0) : new Vector3(0, logSpeed, 0);
        }
        double delay = random.Next(0,10000);

        while(delay < logDelay)
        {
            Thread.Sleep(300);
            delay*=1.2;
        }

        float startingPosition = isRightSpawner ? maxPosition : minPosition;

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, startingPosition);
        logList.Add(Instantiate(logPrefab, spawnPosition, Quaternion.identity));
    }
}
