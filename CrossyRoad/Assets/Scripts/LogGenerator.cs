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

    System.Random random = new System.Random();
    void Start()
    {
        float startingPosition;
        logSpeed = random.Next(1,5)/20f;
        minPosition = this.transform.position.z - 25;
        maxPosition = this.transform.position.z + 25;
        isRightSpawner = (this.transform.position.x) % 2 == 0;
        isLilySpawner = random.Next(0,2) == 0;

        if (isLilySpawner)
        {
            startingPosition = random.Next(15, 35);
            Vector3 spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, startingPosition);
            Instantiate(lilypadPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            startingPosition = isRightSpawner ? maxPosition : minPosition;

            Vector3 spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, startingPosition);
            logList.Add(Instantiate(logPrefab, spawnPosition, Quaternion.identity));
        }

        
    }
    
    private void Update()
    {
        if (isLilySpawner)
        {
            return;
        }

        foreach(GameObject log in logList)
        {
            log.transform.position += isRightSpawner ? new Vector3(0, 0, -logSpeed) : new Vector3(0,0, logSpeed);
            if(log.transform.position.z > maxPosition || log.transform.position.z < minPosition)
            {
                Destroy(log);
            }
        }     
    }
}
