using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovements : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            MoveForward();
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward);
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            Mathf.Round(transform.position.z)
        );
    }
}