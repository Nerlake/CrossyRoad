using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float _cameraSpeed = 1.0f;

    [SerializeField] public bool readyForForwardAnimation = false;
    [SerializeField] private GameObject player;
    private float lastPositionZ = -2;
    [SerializeField] private int distance = 0;


    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - distance);
    }

    private void Update()
    {
        Debug.Log(player.transform.position.z);

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - distance);
        if (player.transform.position.z > lastPositionZ)
        {
            lastPositionZ = player.transform.position.z;
        }
        else
        {
            targetPosition.z = transform.position.z + _cameraSpeed * Time.deltaTime;
        }

        // Utiliser MoveTowards au lieu de Lerp pour un mouvement constant vers la cible
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _cameraSpeed * Time.deltaTime);
    }


}