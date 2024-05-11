using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGeneratorController : MonoBehaviour
{
    [SerializeField] private GameObject[] zones;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject newZone = Instantiate(
                zones[Random.Range(0, zones.Length)],
                transform.position + Vector3.forward * i,
                transform.rotation
            );

            if (Random.Range(0, 2) % 2 == 0)
            {
                newZone.transform.Rotate(Vector3.up * 180);
            }

            newZone.transform.SetParent(this.transform);
        }
    }
}