using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private List<GameObject> roadPrefab;
    [SerializeField] private float minWait = 0.2f, maxWait = 0.5f;

    [SerializeField] public bool reverse = false;

    private GameObject _startPoint;
    private System.Random _random = new System.Random();

    private void Start()
    {
        _startPoint = transform.Find("startPoint").gameObject;
        if (reverse)
            transform.Rotate(Vector3.up, 180);
        StartCoroutine(spawnVehicle());
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("vehicle exit");
        Destroy(other.gameObject);
    }

    private IEnumerator spawnVehicle()
    {
        while (true)
        {
            GameObject car = Instantiate(roadPrefab[Random.Range(0, roadPrefab.Count)], _startPoint.transform.position,
                transform.rotation,
                _startPoint.transform);

            // Ne pas supp j'ai besoin de comprendre pourquoi le 0.26f !
            // car.transform.SetParent(this.transform);
            // car.transform.localPosition = new Vector3(0, 1, 0.26f);

            VehicleMovement vehicleMovement = car.GetComponent<VehicleMovement>();
            vehicleMovement.speed = -10.0f;

            yield return new WaitForSeconds(minWait + (float)_random.NextDouble() * maxWait);
        }
    }
}