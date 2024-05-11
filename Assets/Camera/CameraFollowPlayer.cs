using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject player;

    private float speedMovementCamera = 5f;
    private float offsetZ = 3f;

    private void Start()
    {
        player = GameObject.Find("Player").gameObject;

        transform.position = player.transform.position + Vector3.back * offsetZ + Vector3.up * 4;
        transform.rotation = Quaternion.Euler(30, 0, 0);
    }

    private void Update()
    {
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
    }
}