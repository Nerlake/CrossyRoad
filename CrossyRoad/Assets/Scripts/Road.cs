using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private List<GameObject> roadPrefab;
    [SerializeField] private float minWait = 0.2f, maxWait = 0.5f;
    [SerializeField] private List<GameObject> vehiclePrefab;
    [SerializeField] private GameObject startPoint;
    private bool reverse = false;

    // [SerializeField] public bool reverse = false;

    //private GameObject _startPoint;
    private System.Random _random = new System.Random();

    private void Start()
    {
        if (transform.position.z % 2 == 0)
                transform.Rotate(Vector3.up, 180);
        StartCoroutine(spawnVehicle());
    }


    //private void OnCollisionExit(Collision other)
    //{
    //    Debug.Log("vehicle exit");
    //    Destroy(other.gameObject);
    //}

    private IEnumerator spawnVehicle()
    {
        while (true)
        {
            GameObject car = Instantiate(vehiclePrefab[_random.Next(vehiclePrefab.Count)], startPoint.transform.position, transform.rotation);


            yield return new WaitForSeconds(minWait + (float)_random.NextDouble() * maxWait);
        }
    }
}