using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class RoadContainerController : MonoBehaviour, IMovableContainer
{
    [SerializeField] private GameObject[] vehicles;
    private GameObject killer;
    private GameObject spawner;

    [SerializeField] private float speedOfNewVehicle;
    [SerializeField] private float minWaitBeforeSpawnVehicle;
    [SerializeField] private float maxWaitBeforeSpawnVehicle;

    private void Start()
    {
        killer = transform.Find("Killer").gameObject;
        spawner = transform.Find("Spawner").gameObject;

        StartCoroutine(SpawnVehicles());
    }

    private IEnumerator SpawnVehicles()
    {
        while (true)
        {
            GameObject newVehicle = Instantiate(
                vehicles[Random.Range(0, vehicles.Length)],
                spawner.transform.position,
                spawner.transform.rotation
            );

            newVehicle.GetComponent<IMovable>().SetSpeed(speedOfNewVehicle);
            newVehicle.transform.SetParent(gameObject.transform);

            yield return new WaitForSeconds(Random.Range(minWaitBeforeSpawnVehicle, maxWaitBeforeSpawnVehicle));
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speedOfNewVehicle = newSpeed;
    }
}