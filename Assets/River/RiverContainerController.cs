using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public interface IMovableContainer
{
    public void SetSpeed(float newSpeed);
}

public class RiverContainerController : MonoBehaviour, IMovableContainer
{
    [SerializeField] private GameObject[] logs;
    private GameObject killer;
    private GameObject spawner;

    [SerializeField] private float speedOfNewLog;
    [SerializeField] private float minWaitBeforeSpawnLog;
    [SerializeField] private float maxWaitBeforeSpawnLog;

    private void Start()
    {
        killer = transform.Find("Killer").gameObject;
        spawner = transform.Find("Spawner").gameObject;

        StartCoroutine(SpawnLogs());
    }

    private IEnumerator SpawnLogs()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(1, 5); i++)
            {
                GameObject newVehicle = Instantiate(
                    logs[Random.Range(0, logs.Length)],
                    spawner.transform.position + -transform.right * i,
                    spawner.transform.rotation
                );

                newVehicle.GetComponent<IMovable>().SetSpeed(speedOfNewLog);
                newVehicle.transform.SetParent(gameObject.transform);
            }

            yield return new WaitForSeconds(Random.Range(minWaitBeforeSpawnLog, maxWaitBeforeSpawnLog));
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speedOfNewLog = newSpeed;
    }
}