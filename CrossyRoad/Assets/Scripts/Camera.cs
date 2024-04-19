using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 0.5f;
    [SerializeField] private GameObject player;
    [SerializeField] private bool autoMove = false;
    [SerializeField] private int distanceFromPlayer = 0;
    private float lastPositionZ;


    private void Start()
    {
        lastPositionZ = player.transform.position.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - distanceFromPlayer);
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - distanceFromPlayer);
        if (autoMove)
        {
            if (player.transform.position.z > lastPositionZ)
            {
                lastPositionZ = player.transform.position.z;
            }
            else
            {
                targetPosition.z = transform.position.z + cameraSpeed * Time.deltaTime;
            }

        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraSpeed * Time.deltaTime);

    }

}