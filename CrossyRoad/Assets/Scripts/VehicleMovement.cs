using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        if (transform.position.x < -25 || transform.position.x > 25)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }
}