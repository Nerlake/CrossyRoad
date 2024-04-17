using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LogGenerator : MonoBehaviour
{
    [SerializeField] private GameObject logPrefab;
    [SerializeField] private GameObject lilypadPrefab;
    private float minPosition;
    private float maxPosition;
    [SerializeField] private int logDelay;
    private float logSpeed;
    private bool isLilySpawner;
    private List<GameObject> logList = new List<GameObject>();
    private bool isRightSpawner;
    private float spawnIntervalMin = 1f;
    private float spawnIntervalMax = 3f;

    System.Random random = new System.Random();
    void Start()
    {
        logSpeed = ((random.Next(1,4)) + (random.Next(0,11)/10))/50f;
        minPosition = this.transform.position.x - 25;
        maxPosition = this.transform.position.x + 25;
        isRightSpawner = (this.transform.position.z) % 2 == 0;
        //if x is a multiple of 3 50% to spawn lilypad instead of logs
        isLilySpawner = this.transform.position.z%3 ==0 ? random.Next(0,2) == 0 : false;

        if (isLilySpawner)
        {
            int lilypadNumber = random.Next(1, 6);
            for(int i = 0; i <= lilypadNumber;i++)
            {
                float lilypadStartingPosition = random.Next(-10, 11);
                Vector3 spawnPosition = new Vector3(lilypadStartingPosition, this.transform.position.y, transform.position.z);
                Instantiate(lilypadPrefab, spawnPosition, Quaternion.identity);
            }         
        }
        else
        {

            InvokeRepeating("SpawnLog", UnityEngine.Random.Range(spawnIntervalMin, spawnIntervalMax), UnityEngine.Random.Range(spawnIntervalMin, spawnIntervalMax));

            //logList.Add(Instantiate(logPrefab, spawnPosition, Quaternion.identity));
        }
    }
    
    private void Update()
    {
        if (isLilySpawner)
        {
            return;
        }

        for(int i =0; i< logList.Count;i++)// GameObject log in logList)
        {
            GameObject log = logList[i];
            log.transform.position += isRightSpawner ? new Vector3(-logSpeed, 0, 0) : new Vector3(logSpeed, 0, 0);
            if(log.transform.position.x > maxPosition || log.transform.position.x < minPosition)
            {
                Destroy(log);
                logList.Remove(log);
            }
        }     
    }

    void SpawnLog()
    {

        float logStartingPosition = isRightSpawner ? maxPosition : minPosition;

        Vector3 spawnPosition = new Vector3(logStartingPosition, this.transform.position.y, transform.position.z);

        GameObject newLog = Instantiate(logPrefab, spawnPosition, Quaternion.identity);
        logList.Add(newLog);
    }
}
