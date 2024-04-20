using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LogGenerator : MonoBehaviour
{

    [SerializeField] private float minWait = 0.2f, maxWait = 0.5f;
    [SerializeField] private List<GameObject> logPrefab;
    [SerializeField] private GameObject startPoint;

    private System.Random _random = new System.Random();

    private void Start()
    {
        if (transform.position.z % 2 == 0)
            transform.Rotate(Vector3.up, 180);
        StartCoroutine(spawnLog());
    }

    private IEnumerator spawnLog()
    {
        while (true)
        {

            float waitTime = minWait + (float)_random.NextDouble() * (maxWait - minWait);
            yield return new WaitForSeconds(waitTime);
            GameObject log = Instantiate(logPrefab[_random.Next(logPrefab.Count)], startPoint.transform.position, transform.rotation);
            log.tag = "Log";
        }
    }

}
