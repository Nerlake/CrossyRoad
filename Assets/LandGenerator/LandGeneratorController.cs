using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LandGeneratorController : MonoBehaviour
{
    [SerializeField] private GameObject[] zones;

    private float positionOfLastZoneInZ = 0;

    private void Start()
    {
        for (; positionOfLastZoneInZ < 20; positionOfLastZoneInZ++)
        {
            GameObject newZone = Instantiate(
                zones[Random.Range(0, zones.Length)],
                transform.position + Vector3.forward * positionOfLastZoneInZ,
                transform.rotation
            );

            if (Random.Range(0, 2) % 2 == 0)
            {
                newZone.transform.Rotate(Vector3.up * 180);
            }

            newZone.transform.SetParent(this.transform);
        }
    }

    private void Update()
    {
        CheckIfNeedNewZone();
    }

    private void CheckIfNeedNewZone()
    {
        GameObject firstZoneContainer = transform.GetChild(0).Find("PlayableZone").gameObject;
        Renderer firstZoneRenderer = firstZoneContainer.GetComponent<Renderer>();

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, firstZoneRenderer.bounds))
        {
            print("LandGenerator: La 1er zone n'est plus dans la FOV il va être détruit");
            Destroy(firstZoneContainer.transform.parent.gameObject);

            print("LandGenerator: Une zone va être ajouté à la fin");
            AddNewZone();
        }
    }

    private void AddNewZone()
    {
        GameObject newZone = Instantiate(
            zones[Random.Range(0, zones.Length)],
            transform.position + Vector3.forward * positionOfLastZoneInZ++,
            transform.rotation
        );

        if (Random.Range(0, 2) % 2 == 0)
        {
            newZone.transform.Rotate(Vector3.up * 180);
        }

        newZone.transform.SetParent(this.transform);
    }
}