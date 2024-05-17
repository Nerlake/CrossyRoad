using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject player;

    private float speedMovementCamera = 8f;
    private float offsetZ = 3f;
    private float lastCameraZ;

    private void Start()
    {
        player = GameObject.Find("Player").gameObject;

        transform.position = player.transform.position + Vector3.back * offsetZ + Vector3.up * 4;
        transform.rotation = Quaternion.Euler(50, 0, 0);
        lastCameraZ = transform.position.z;
    }

    private void Update()
    {
        if (lastCameraZ > player.transform.position.z - offsetZ)
        {
            return;
        }

        Vector3 targetPositionOfCamera = new Vector3(
            // player.transform.position.x,
            transform.position.x,
            transform.position.y,
            player.transform.position.z - offsetZ
        );
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPositionOfCamera,
            speedMovementCamera * Time.deltaTime
        );

        lastCameraZ = transform.position.z;
    }
}