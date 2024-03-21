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
        minPosition = this.transform.position.z - 25;
        maxPosition = this.transform.position.z + 25;
        isRightSpawner = (this.transform.position.x) % 2 == 0;
        //if x is a multiple of 3 50% to spawn lilypad instead of logs
        isLilySpawner = this.transform.position.x%3 ==0 ? random.Next(0,2) == 0 : false;

        if (isLilySpawner)
        {
            int lilypadNumber = random.Next(1, 6);
            for(int i = 0; i <= lilypadNumber;i++)
            {
                float lilypadStartingPosition = random.Next(-10, 11);
                Vector3 spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, lilypadStartingPosition);
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
            log.transform.position += isRightSpawner ? new Vector3(0, 0, -logSpeed) : new Vector3(0,0, logSpeed);
            if(log.transform.position.z > maxPosition || log.transform.position.z < minPosition)
            {
                Destroy(log);
                logList.Remove(log);
            }
        }     
    }

    void SpawnLog()
    {

        float logStartingPosition = isRightSpawner ? maxPosition : minPosition;

        Vector3 spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, logStartingPosition);

        GameObject newLog = Instantiate(logPrefab, spawnPosition, Quaternion.identity);
        logList.Add(newLog);
    }
}
