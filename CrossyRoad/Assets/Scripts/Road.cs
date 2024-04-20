using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private float minWait = 0.2f, maxWait = 0.5f;
    [SerializeField] private List<GameObject> vehiclePrefab;
    [SerializeField] private GameObject startPoint;

    // [SerializeField] public bool reverse = false;

    //private GameObject _startPoint;
    private System.Random _random = new System.Random();

    private void Start()
    {
        if (transform.position.z % 2 == 0)
                transform.Rotate(Vector3.up, 180);
        StartCoroutine(spawnVehicle());
    }

    private IEnumerator spawnVehicle()
    {
        while (true)
        {

            float waitTime = minWait + (float)_random.NextDouble() * (maxWait - minWait);
            yield return new WaitForSeconds(waitTime);
            GameObject newCar = Instantiate(vehiclePrefab[_random.Next(vehiclePrefab.Count)], startPoint.transform.position, transform.rotation);
            newCar.transform.SetParent(transform);
        }
    }
}